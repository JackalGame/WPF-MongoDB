using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MongoDB.Driver;

namespace MotorbikeStockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadManufactureList();
        }

        #region Buttons
        private void btnNewAddMotorcycle(object sender, RoutedEventArgs e)
        {
            AddMotorcycleWindow addMotoWin = new AddMotorcycleWindow();
            addMotoWin.ShowDialog();
            LoadManufactureList();
            ShowFilteredMotorcycles();
        }

        private void btnRemoveSelectedItem(object sender, RoutedEventArgs e)
        {
            // Check that a record has been selected            
            if(listMotorcycles.SelectedItem != null)
            {
                MotorcycleModel selectedItem = (MotorcycleModel)listMotorcycles.SelectedItem;

                if (MessageBox.Show($"Are you sure that you wish to perminantly remove{Environment.NewLine}" +
                    $"vehicle record for {selectedItem.VehicleRegistration}", 
                    "Delete Record", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    // do nothing
                }
                else // Delete Record
                {
                    MongoCRUD db = new MongoCRUD("StockList");

                    MessageBox.Show("Record Deleted");

                    db.DeleteRecord<MotorcycleModel>("Motorcycles", selectedItem.Id);

                    LoadManufactureList();
                    ShowFilteredMotorcycles();
                }
            }
            else
            {
                MessageBox.Show("No item selected");
            }
 
        }

        private void btnSeePreviousOwner(object sender, RoutedEventArgs e)
        {
            // Check that a record has been selected            
            if (listMotorcycles.SelectedItem != null)
            {
                MotorcycleModel selectedItem = (MotorcycleModel)listMotorcycles.SelectedItem;

                MessageBox.Show($"Name: {selectedItem.PreviousOwner.FullName}{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"Address:-{Environment.NewLine} " +
                    $"{selectedItem.PreviousOwner.AddressLine1}{Environment.NewLine}" +
                    $"{selectedItem.PreviousOwner.AddressLine2}{Environment.NewLine}" +
                    $"{selectedItem.PreviousOwner.AddressLine3}{Environment.NewLine}" +
                    $"{selectedItem.PreviousOwner.AddressLine4}{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"Postcode: {selectedItem.PreviousOwner.Postcode}{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"Telephone Number: {selectedItem.PreviousOwner.TelephoneNumber}","Previous Owner Details");
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }

        private void btnEditSelectedItem(object sender, RoutedEventArgs e)
        {
            if (listMotorcycles.SelectedItem != null)
            {
                MotorcycleModel selectedMotorcycle = (MotorcycleModel)listMotorcycles.SelectedItem;
                EditMotorcycleWindow editMotoWin = new EditMotorcycleWindow(selectedMotorcycle.Id);

                editMotoWin.ShowDialog();

                LoadManufactureList();
                ShowFilteredMotorcycles();
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }
        #endregion



        // Manufacturer Filter Drop Down Box
        private void LoadManufactureList()
        {
            MongoCRUD db = new MongoCRUD("StockList");

            var manufaturerList = db.LoadDistinctList<MotorcycleModel>("Motorcycles");

            List<string> distinctManufacturerList = new List<string>();

            foreach (var manu in manufaturerList)
            {
                distinctManufacturerList.Add(manu.Manufacturer);
            }


            // Further consider obtaining distinct list direct from MongoDB
            distinctManufacturerList = distinctManufacturerList.Distinct().ToList();

            distinctManufacturerList.Sort();

            listManufacturers.Items.Clear();

            foreach (var manu in distinctManufacturerList)
            {
                listManufacturers.Items.Add(manu);
            }
        }

        // Show Motorcycles Filted by Manufacturer
        private void ShowFilteredMotorcycles()
        {
            MongoCRUD db = new MongoCRUD("StockList");

            List<MotorcycleModel> motorcycles = db.LoadFilteredList<MotorcycleModel>("Motorcycles", listManufacturers.Text);

            listMotorcycles.Items.Clear();

            foreach (var m in motorcycles)
            {
                listMotorcycles.Items.Add(m);
            }
        }

        private void listManufacturers_DownDownClosed(object sender, EventArgs e)
        {
            ShowFilteredMotorcycles();
        }
    }
}
