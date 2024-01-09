using System;
namespace AutoMapperDemo
{
                   //Traditional approach
    class Program
    {
        static void Main(string[] args)
        {
            // Employee Object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Mapping Employee Object to Employee2 Object
            Employee2 emp2 = new Employee2
            {
                Name = emp.Name,
                Salary = emp.Salary,
                Address = emp.Address,
                Department = emp.Department
            };

            Console.WriteLine("Name:" + emp2.Name + ", Salary:" + emp2.Salary + ", Address:" + emp2.Address + ", Department:" + emp2.Department);
            Console.ReadLine();
        }
    }

        public class Employee
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public string Address { get; set; }
            public string Department { get; set; }
        }

        public class Employee2
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public string Address { get; set; }
            public string Department { get; set; }
        }
    
}