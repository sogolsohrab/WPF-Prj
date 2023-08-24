using DataAccess.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Models.Employee;
using System.Net;

namespace DataAccess
{
    public class EmployeeDataAccess
    {
        private string path = @"./DemoDBEmployees.csv";
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public EmployeeDataAccess()
        {
            ReadEmployee();
        }


        /*
        // Static DataBase
        private void ReadEmployee()
        {
            Employee emp1 = new Employee()
            {
                Id = 1,
                FirstName = "Sogol",
                LastName = "Sohrab",
                Address = "Tehran, Shademan, 225",
                PhoneNumber = 989102008534,
                BaseSalary = 500,
                Department = Employee.Departments.Sales,

            };
            Employee emp2 = new Employee()
            {
                Id = 2,
                FirstName = "Erfan",
                LastName = "Abbasi",
                Address = "Tehran, Satarkhan, 15",
                PhoneNumber = 989025456820,
                BaseSalary = 300,
                Department = Employee.Departments.Production,
            };

            Employees.Add(emp1);
            Employees.Add(emp2);
        }
        */

        private void ReadEmployee()
        {
            using (var reader = new StreamReader(path))
            {
                Employees.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    Enum.TryParse(values[5], out Departments dept);

                    Employee emp = new Employee()
                    {
                        Id = Convert.ToInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = Convert.ToUInt64(values[3]),
                        Address = values[4],
                        Department = dept,
                        BaseSalary = Convert.ToDecimal(values[6]),
                    };
                    Employees.Add(emp);
                }
            }
        }

        private void SaveEmployee()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Employee emp in Employees)
                {
                    string Id = emp.Id.ToString();
                    string FirstName = emp.FirstName;
                    string LastName = emp.LastName;
                    string PhoneNumber = emp.PhoneNumber.ToString();
                    string Address = emp.Address;
                    string Department = emp.Department.ToString();
                    string BaseSalary = emp.BaseSalary.ToString();

                    string line = string.Format("{0};{1};{2};{3};{4};{5};{6}",Id, FirstName, LastName, PhoneNumber, Address, Department, BaseSalary);
                    writer.WriteLine(line);
                }
            }
        }

        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            SaveEmployee();
        }

        public void DeleteEmployee(int id)
        {
            Employee temp = Employees.First(x => x.Id == id);
            if (temp != null)
            {
                Employees.Remove(temp);
                SaveEmployee();

            }
        }

        public void UpdateEmployee(Employee employee)
        {
            int index = Employees.IndexOf(employee);
            Employees[index] = employee;
            SaveEmployee();
            /*
            Employee temp = Employees.First(x => x.Id == employee.Id);
            if (temp != null)
            {
                int index = Employees.IndexOf(temp);
                Employees[index] = employee;
                SaveEmployee();
            }
            */
        }
    }
}
