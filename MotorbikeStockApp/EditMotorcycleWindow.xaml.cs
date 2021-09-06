using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MotorbikeStockApp
{
    /// <summary>
    /// Interaction logic for EditMotorcycleWindow.xaml
    /// </summary>
    public partial class EditMotorcycleWindow : Window
    {
        Guid id;
            
        public EditMotorcycleWindow(Guid motorcycleID)
        {
            id = motorcycleID;
            
            InitializeComponent();
            vehiclePurchaseDate.DisplayDateEnd = DateTime.Today;
            FillInData(id);
        }

        private void FillInData(Guid id)
        {
            MongoCRUD db = new MongoCRUD("StockList");

            MotorcycleModel selectedMotorcycle = db.FindRecord<MotorcycleModel>("Motorcycles", id);

            vehicleReg.Text = selectedMotorcycle.VehicleRegistration;
            vehicleManufacturer.Text = selectedMotorcycle.Manufacturer;
            vehicleModel.Text = selectedMotorcycle.Model;
            vehicleMillage.Text = selectedMotorcycle.Millage.ToString();
            vehiclePurchaseDate.SelectedDate = selectedMotorcycle.DatePurchased;

            firstName.Text = selectedMotorcycle.PreviousOwner.FirstName;
            surname.Text = selectedMotorcycle.PreviousOwner.Surname;
            address1.Text = selectedMotorcycle.PreviousOwner.AddressLine1;
            address2.Text = selectedMotorcycle.PreviousOwner.AddressLine2;
            address3.Text = selectedMotorcycle.PreviousOwner.AddressLine3;
            address4.Text = selectedMotorcycle.PreviousOwner.AddressLine4;
            postcode.Text = selectedMotorcycle.PreviousOwner.Postcode;
            telephoneNo.Text = selectedMotorcycle.PreviousOwner.TelephoneNumber;
        }

        // Checking to see whether all mandarory data has been inputted.
        private void CheckMandatoryFields()
        {
            bool errorsFound = false;

            TextBox[] mandatoryTextboxs = new TextBox[] {
                vehicleManufacturer, vehicleModel, vehicleMillage,
                firstName, surname, address1, postcode, telephoneNo };


            foreach (TextBox textbox in mandatoryTextboxs)
            {
                if (textbox.Text == null || textbox.Text == "")
                {
                    textbox.Background = Brushes.LightCoral;
                    errorsFound = true;
                }
                else
                {
                    textbox.Background = Brushes.White;
                }
            }


            // Check that a date has been entered
            if (vehiclePurchaseDate.SelectedDate == null)
            {
                vehiclePurchaseDate.Background = Brushes.LightCoral;
                errorsFound = true;
            }
            else
            {
                vehiclePurchaseDate.Background = Brushes.White;
            }


            // Check if any errors were recorded
            // If errors recorded, return to add screen
            // If no errors, execute code to add motorcycle
            if (errorsFound)
            {
                MessageBox.Show("Missing mandatory data. Please see highlighted fields.");
            }
            else
            {
                UpdateRecord(id);
                this.Close();
            }

        }

        private void UpdateRecord(Guid id)
        {
            MongoCRUD db = new MongoCRUD("StockList");

            MotorcycleModel selectedMotorcycle = db.FindRecord<MotorcycleModel>("Motorcycles", id);

            selectedMotorcycle.Manufacturer = vehicleManufacturer.Text;
            selectedMotorcycle.Model = vehicleModel.Text;
            selectedMotorcycle.Millage = Int32.Parse(vehicleMillage.Text);
            selectedMotorcycle.DatePurchased = vehiclePurchaseDate.DisplayDate.Date;

            selectedMotorcycle.PreviousOwner.FirstName = firstName.Text;
            selectedMotorcycle.PreviousOwner.Surname = surname.Text;
            selectedMotorcycle.PreviousOwner.FullName = $"{firstName.Text} {surname.Text}";
            selectedMotorcycle.PreviousOwner.AddressLine1 = address1.Text;
            selectedMotorcycle.PreviousOwner.AddressLine2 = address2.Text;
            selectedMotorcycle.PreviousOwner.AddressLine3 = address3.Text;
            selectedMotorcycle.PreviousOwner.AddressLine4 = address4.Text;
            selectedMotorcycle.PreviousOwner.Postcode = postcode.Text.ToUpper();
            selectedMotorcycle.PreviousOwner.TelephoneNumber = telephoneNo.Text;

            db.UpsertRecord("Motorcycles", selectedMotorcycle.VehicleRegistration, selectedMotorcycle);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region Buttons
        private void btnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm(object sender, RoutedEventArgs e)
        {
            CheckMandatoryFields();
        }
        #endregion
    }
}
