using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }
        public Departments Department { get; set; }
        public decimal BaseSalary { get; set; }

        public string GetBasicInfo()
        {
            string finalStr = FirstName + " " + LastName +
                "\nPhone: " + PhoneNumber +
                "\nAddress: " + Address +
                "\nDepartment: " + Department +
                "\nBase Salary: " + BaseSalary;

            return finalStr;
        }

        public enum Departments
        {
            Production,
            Sales,
            Advertisment,
            Management
        }
    }
}
