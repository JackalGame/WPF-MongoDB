using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace MotorbikeStockApp
{
    /// <summary>
    /// Interaction logic for AddMotorcycleWindow.xaml
    /// </summary>
    public partial class AddMotorcycleWindow : Window
    {
        public AddMotorcycleWindow()
        {
            InitializeComponent();
            vehiclePurchaseDate.DisplayDateEnd = DateTime.Today;
        }


        #region Buttons
        // Interactive Buttons
        private void btnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm(object sender, RoutedEventArgs e)
        {
            CheckMandatoryFields();
        }
        #endregion




        #region Methods
        // Checking to see whether all mandarory data has been inputted.
        private void CheckMandatoryFields()
        {
            bool errorsFound = false;
            
            TextBox[] mandatoryTextboxs = new TextBox[] { 
                vehicleReg, vehicleManufacturer, vehicleModel, vehicleMillage,
                firstName, surname, address1, postcode, telephoneNo };

            
            foreach (TextBox textbox in mandatoryTextboxs)
            {
                if(textbox.Text == null || textbox.Text == "")
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
            if(vehiclePurchaseDate.SelectedDate == null)
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
                InsertNewMotorcycle();
                this.Close();
            }

        }



        // Read input fields from GUI
        // Create new model using inputted data
        private MotorcycleModel CreateNewMotorcycle()
        {

            MotorcycleModel newMotorcycle = new MotorcycleModel
            {
                VehicleRegistration = vehicleReg.Text.ToUpper(),
                Manufacturer = vehicleManufacturer.Text,
                Model = vehicleModel.Text,
                Millage = Int32.Parse(vehicleMillage.Text),
                DatePurchased = vehiclePurchaseDate.DisplayDate.Date,

                PreviousOwner = new PersonModel
                {
                    FirstName = firstName.Text,
                    Surname = surname.Text,
                    FullName = $"{firstName.Text} {surname.Text}",

                    AddressLine1 = address1.Text,
                    AddressLine2 = address2.Text,
                    AddressLine3 = address3.Text,
                    AddressLine4 = address4.Text,

                    Postcode = postcode.Text.ToUpper(),

                    TelephoneNumber = telephoneNo.Text
                }
            };

            return newMotorcycle;
        }


        // Insert New Motorcycle Logic
        // If record doesn't already exist
        private void InsertNewMotorcycle()
        {
            MongoCRUD db = new MongoCRUD("StockList");

            MotorcycleModel newMotorcycle = CreateNewMotorcycle();
            
            if(db.CheckForExistingRecord<MotorcycleModel>("Motorcycles", newMotorcycle.VehicleRegistration))
            {
                MessageBox.Show($"Vehicle already exists.{Environment.NewLine}Please check the list.");
            }
            else
            {
                db.InsertRecord("Motorcycles", newMotorcycle);
                MessageBox.Show("New motorcycle added");
            }
        }
        #endregion

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
