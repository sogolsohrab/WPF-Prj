using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        private string path = @"./DemoDBCustomers.csv";

        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public CustomerDataAccess()
        {
            ReadCustomer();
        }

        /*
        // Static DataBase
        private void ReadCustomer()
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Jon",
                LastName = "Doe",
                Address = "Tehran, Mirdamad 54",
                PhoneNumber = 981205425059,
            };
            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Rose",
                LastName = "Katty",
                Address = "Tehran, Pirozi 23",
                PhoneNumber = 981574187179,
            };

            Customers.Add(customer1);
            Customers.Add(customer2);
        }
        */

        private void ReadCustomer()
        {
            using (var reader = new StreamReader(path))
            {
                Customers.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    Customer customer = new Customer()
                    {
                        Id = Convert.ToInt32(values[0]),    
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = Convert.ToUInt64(values[3]),
                        Address = values[4],
                    };
                    Customers.Add(customer);
                }
            }
        }

        private void SaveCustomer()
        {
            using(var writer = new StreamWriter(path))
            {
                foreach (Customer customer in Customers)
                {
                    string Id = customer.Id.ToString();
                    string FirstName = customer.FirstName;
                    string LastName = customer.LastName;
                    string PhoneNumber = customer.PhoneNumber.ToString();
                    string Address = customer.Address;

                    string line = String.Format("{0};{1};{2};{3};{4}",Id, FirstName, LastName, PhoneNumber, Address);
                    writer.WriteLine(line);
                }
            }
        }

        public int GetNextId()
        {
            int index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        }

        public void AddCustomer(Customer cus)
        {
            Customers.Add(cus);
            SaveCustomer();
        }

        public void DeleteCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);
            if (temp != null)
            {
                Customers.Remove(temp);
                SaveCustomer();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer temp = Customers.First(x => x.Id == customer.Id);
            if (temp != null)
            {
                int index = Customers.IndexOf(temp);
                Customers[index] = customer;
                SaveCustomer();
            }
        }
    }
}
