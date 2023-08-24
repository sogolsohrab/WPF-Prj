using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Models.Employee;

namespace DataAccess
{
    public class ProductDataAccess
    {
        private string path = @"./DemoDBProducts.csv";
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductDataAccess()
        {
            ReadProduct();
        }

        /*
        // Static DataBase
        private void ReadProduct()
        {
            Product pr1 = new Product()
            {
                Id = 1,
                Name = "Animal Farm",
                Author = "George Orwell",
                AvailableCount = 12,
                Price = 17,
            };

            Product pr2 = new Product()
            {
                Id = 2,
                Name = "Brave New World",
                Author = "Aldous Huxley",
                AvailableCount = 5,
                Price = 34,
            };

            Products.Add(pr1);
            Products.Add(pr2);
        }
        */


        private void ReadProduct()
        {
            using (var reader = new StreamReader(path))
            {
                Products.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    Product product = new Product()
                    {
                        Id = Convert.ToInt32(values[0]),
                        Name = values[1], 
                        Author = values[2],
                        Price = Convert.ToDecimal(values[3]),
                        AvailableCount = Convert.ToInt32(values[4]),
                    };
                    Products.Add(product);
                }
            }
        }

        private void SaveProduct()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Product product in Products)
                {
                    string Id = product.Id.ToString();
                    string Name = product.Name;
                    string Author = product.Author;
                    string Price = product.Price.ToString();
                    string AvailableCount = product.AvailableCount.ToString();

                    string line = string.Format("{0};{1};{2};{3};{4}",Id, Name, Author, Price, AvailableCount);
                    writer.WriteLine(line);
                }
            }
        }
        public int GetNextId()
        {
            int index = Products.Any() ? Products.Max(p => p.Id) + 1 : 1;
            return index;
        }

        public void AddProduct(Product prd)
        {
            Products.Add(prd);
            SaveProduct();
        }

        public void DeleteProduct(int id)
        {
            Product temp = Products.First(p => p.Id == id);
            if (temp != null)
            {
                Products.Remove(temp);
                SaveProduct();
            }
        }

        public void UpdateProduct(Product product)
        {
            Product temp = Products.First(p => p.Id == product.Id);
            int index = Products.IndexOf(temp);
            Products[index] = product;
            SaveProduct();
        }
    }
}
