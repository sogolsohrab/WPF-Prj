using DataAccess.Models;
using DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApplicationBookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        ObservableCollection<Employee> Empolyees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> Products = new ObservableCollection<Product>();

        public Employee currentEmployee { get; set; } = new Employee();
        public Customer currentCustomer { get; set; } = new Customer();
        public Product currentProduct { get; set; } = new Product();

        public MainWindow()
        {
            InitializeComponent();
            fillData();
            EmployeesGrid.ItemsSource = Empolyees;
            CustomersGrid.ItemsSource = Customers;
            ProductGrid.ItemsSource = Products;
        }

        private void fillData()
        {
            Empolyees = employeeDataAccess.Employees;
            Customers = customerDataAccess.Customers;
            Products = productDataAccess.Products;
        }


        // First Column Buttons
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmpolyeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;

        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmpolyeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmpolyeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;

        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmpolyeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }


        // EmployeesPanel
        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLabel.Content = currentEmployee.GetBasicInfo();
                
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess);
            addWindow.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                employeeDataAccess.DeleteEmployee(currentEmployee.Id);
                EmployeeLabel.Content = "---";

            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess, currentEmployee);
                addWindow.ShowDialog();

            }
        }


        // CustomersPanel
        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                CustomerLabel.Content = currentCustomer.GetBasicInfo();
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer newWindow = new AddEditCustomer(customerDataAccess);
            newWindow.ShowDialog();

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                AddEditCustomer newWindow = new AddEditCustomer(customerDataAccess, currentCustomer);
                newWindow.ShowDialog();
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                customerDataAccess.DeleteCustomer(currentCustomer.Id);
                CustomerLabel.Content = "---";
            }

        }


        // ProductsPanel
        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                ProductLabel.Content = currentProduct.GetBasicInfo();
            }

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct newWindow = new AddEditProduct(productDataAccess);
            newWindow.ShowDialog();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >=0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                AddEditProduct newWindow = new AddEditProduct(productDataAccess, currentProduct);
                newWindow.ShowDialog();
            }

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                productDataAccess.DeleteProduct(currentProduct.Id);
                ProductLabel.Content = "----";
            }
        }
    }
}
