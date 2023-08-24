using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private ProductDataAccess productDataAccess;
        private Product editingProduct;
        private bool isEdit = false;

        public AddEditProduct(ProductDataAccess prdDataAccess)
        {
            InitializeComponent();
            productDataAccess = prdDataAccess;
        }
        public AddEditProduct(ProductDataAccess prdDataAccess, Product product)
        {
            InitializeComponent();
            productDataAccess = prdDataAccess;
            editingProduct = product;
            isEdit = true;
            tbName.Text = editingProduct.Name;
            tbAuthor.Text = editingProduct.Author;
            tbAvailableCount.Text = editingProduct.AvailableCount.ToString();
            tbPrice.Text = editingProduct.Price.ToString();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckProductValidity();
            if (isValid)
            {
                if (isEdit)
                {
                    Product product = new Product()
                    {
                        Id = editingProduct.Id,
                        Name = tbName.Text,
                        Author = tbAuthor.Text,
                        AvailableCount = Convert.ToInt32(tbAvailableCount.Text),
                        Price = Convert.ToDecimal(tbPrice.Text)
                    };
                    productDataAccess.UpdateProduct(product);
                }
                else
                {
                    Product product = new Product()
                    {
                        Id = productDataAccess.GetNextId(),
                        Name = tbName.Text,
                        Author = tbAuthor.Text,
                        AvailableCount = Convert.ToInt32(tbAvailableCount.Text),
                        Price = Convert.ToDecimal(tbPrice.Text)
                    };
                    productDataAccess.AddProduct(product);
                }
                this.Close();

            }

        }

        private bool CheckProductValidity()
        {
            bool isValid = true;
            string name = tbName.Text.Trim().ToLower();
            string author = tbAuthor.Text.Trim().ToLower();
            string availableCount = tbAvailableCount.Text.Trim().ToLower();
            string price = tbPrice.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(name))
            {
                isValid = false;
                lblError.Content = "**Note: Name is invalid!";
                tbName.BorderBrush = Brushes.MediumVioletRed;
            }
            else if (string.IsNullOrEmpty(author))
            {
                isValid = false;
                lblError.Content = "**Note: Author is invalid!";
                tbName.BorderBrush = Brushes.MediumAquamarine;
                tbAuthor.BorderBrush = Brushes.MediumVioletRed;
            } 
            else if (!decimal.TryParse(price, out decimal d))
            {
                isValid = false;
                lblError.Content = "**Note: Price is invalid!";
                tbName.BorderBrush = Brushes.MediumAquamarine;
                tbAuthor.BorderBrush = Brushes.MediumAquamarine;
                tbAvailableCount.BorderBrush = Brushes.MediumAquamarine;
                tbPrice.BorderBrush = Brushes.MediumVioletRed;

            }
            else if (!Int32.TryParse(availableCount, out int p))
            {
                isValid = false;
                lblError.Content = "**Note: Available Count is invalid!";
                tbName.BorderBrush = Brushes.MediumAquamarine;
                tbAuthor.BorderBrush = Brushes.MediumAquamarine;
                tbAvailableCount.BorderBrush = Brushes.MediumVioletRed;

            }
            else
            {
                lblError.Content = "";
            }

            return isValid;
        }

    }
}
