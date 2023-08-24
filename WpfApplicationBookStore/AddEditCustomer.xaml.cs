using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplicationBookStore
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerDataAccess customerDataAccess;
        private Customer editingCustomer;
        private bool isEdit = false;

        public AddEditCustomer(CustomerDataAccess custDataAccess)
        {
            InitializeComponent();
            customerDataAccess = custDataAccess;
        }

        public AddEditCustomer(CustomerDataAccess custDataAccess,Customer customer)
        {
            InitializeComponent();
            customerDataAccess = custDataAccess;
            editingCustomer = customer;
            isEdit = true;
            tbFirstName.Text = editingCustomer.FirstName;
            tbLastName.Text = editingCustomer.LastName;
            tbPhoneNumber.Text = editingCustomer.PhoneNumber.ToString();
            tbAddress.Text = editingCustomer.Address;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckCustomerValidity();
            if (isValid)
            {
                if (isEdit)
                {
                    Customer customer = new Customer()
                    {
                        Id = editingCustomer.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                    };
                    customerDataAccess.UpdateCustomer(customer);

                }
                else
                {
                    Customer customer = new Customer()
                    {
                        Id = customerDataAccess.GetNextId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                    };
                    customerDataAccess.AddCustomer(customer);

                }
                this.Close();
            }
           

        }

        private bool CheckCustomerValidity()
        {
            bool isValid = true;
            string firstName = tbFirstName.Text.Trim().ToLower();
            string lastName = tbLastName.Text.Trim().ToLower();
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string address = tbAddress.Text.Trim().ToLower();


            if (string.IsNullOrEmpty(firstName))
            {
                isValid = false;
                //MessageBox.Show("First Name is invalid!");
                lblError.Content = "**Note: First Name is invalid!";
                tbFirstName.BorderBrush = Brushes.MediumVioletRed;
            }
            else if (string.IsNullOrEmpty(lastName))
            {
                isValid = false;
                //MessageBox.Show("Last Name is invalid!");
                lblError.Content = "**Note: Last Name is invalid!";
                tbFirstName.BorderBrush = Brushes.MediumAquamarine;
                tbLastName.BorderBrush = Brushes.MediumVioletRed;

            } 
            else if (!UInt64.TryParse(phoneNumber, out ulong p))
            {
                isValid = false;
                //MessageBox.Show("Phone Number is invalid!");
                lblError.Content = "**Note: Phone Number is invalid!";
                tbFirstName.BorderBrush = Brushes.MediumAquamarine;
                tbLastName.BorderBrush = Brushes.MediumAquamarine;
                tbPhoneNumber.BorderBrush = Brushes.MediumVioletRed;

            }
            else if (string.IsNullOrEmpty(address))
            {
                isValid = false;
                //MessageBox.Show("Address is not valid!");
                lblError.Content = "**Note: Address is not valid!";
                tbFirstName.BorderBrush = Brushes.MediumAquamarine;
                tbLastName.BorderBrush = Brushes.MediumAquamarine;
                tbPhoneNumber.BorderBrush = Brushes.MediumAquamarine;
                tbAddress.BorderBrush = Brushes.MediumVioletRed;

            }
            else
            {
                lblError.Content = "";
            }


            return isValid;
        }


    }
}
