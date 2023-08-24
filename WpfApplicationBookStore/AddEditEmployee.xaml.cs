using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static DataAccess.Models.Employee;

namespace WpfApplicationBookStore
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess;
        private Employee editingEmployee;
        private bool isEdit = false;

        // Constructor
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }

        public AddEditEmployee(EmployeeDataAccess empDataAccess, Employee employee)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = employee;
            isEdit = true;
            tbFirstName.Text = editingEmployee.FirstName;
            tbLastName.Text = editingEmployee.LastName;
            tbPhoneNumber.Text = editingEmployee.PhoneNumber.ToString();
            tbAddress.Text = editingEmployee.Address;
            tbBaseSalary.Text = editingEmployee.BaseSalary.ToString();
            comboDepartment.SelectedIndex = (int)editingEmployee.Department;
        }

        // Cancel / Save Button 
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckEmployeeValidity();

            if (isValid)
            {
                if (isEdit)
                {
                    Employee employee = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbBaseSalary.Text),
                        Department = (Departments)comboDepartment.SelectedIndex
                    };
                    employeeDataAccess.UpdateEmployee(employee);

                }
                else
                {
                    Employee employee = new Employee()
                    {
                        Id = employeeDataAccess.GetNextId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbBaseSalary.Text),
                        Department = (Departments)comboDepartment.SelectedIndex
                    };
                    employeeDataAccess.AddEmployee(employee);
                }
                this.Close();
            }
 
        }

        private bool CheckEmployeeValidity()
        {
            bool isValid = true;
            string firstName = tbFirstName.Text.Trim().ToLower();
            string lastName = tbLastName.Text.Trim().ToLower();
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string address = tbAddress.Text.Trim().ToLower();
            int department = comboDepartment.SelectedIndex;
            string baseSalary = tbBaseSalary.Text.Trim().ToLower();

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
            else if (department < 0)
            {
                isValid = false;
                //MessageBox.Show("Please select a Department!");
                lblError.Content = "**Note: Please select a Department!";
                tbFirstName.BorderBrush = Brushes.MediumAquamarine;
                tbLastName.BorderBrush = Brushes.MediumAquamarine;
                tbPhoneNumber.BorderBrush = Brushes.MediumAquamarine;
                tbAddress.BorderBrush = Brushes.MediumAquamarine;
                comboDepartment.BorderBrush = Brushes.MediumVioletRed;

            }
            else if (!decimal.TryParse(baseSalary, out decimal b)) 
            {
                isValid = false;
                //MessageBox.Show("Base Salary is invalid!");
                lblError.Content = "**Note: Base Salary is invalid!";

                tbFirstName.BorderBrush = Brushes.MediumAquamarine;
                tbLastName.BorderBrush = Brushes.MediumAquamarine;
                tbPhoneNumber.BorderBrush = Brushes.MediumAquamarine;
                tbAddress.BorderBrush = Brushes.MediumAquamarine;
                comboDepartment.BorderBrush = Brushes.MediumAquamarine;
                tbBaseSalary.BorderBrush = Brushes.MediumVioletRed;
            }
            else
            {
                lblError.Content = "";
            }

            return isValid;
        }

        /*
         // Checks the validity while user is typing
         // Don't forget to add TextChanged="tbPhoneNumber_TextChanged" in xaml file of tbPhoneNumber
        private void tbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            if (!UInt64.TryParse(phoneNumber, out ulong p))
            {
                lblError.Content = "Phone Number is invalid!";
            } else
            {
                lblError.Content = "";
            }
        }
        */
    }
}
