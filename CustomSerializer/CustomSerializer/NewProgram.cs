using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerializer
{


    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Id { get; set; }

        public void CalculateSalary()
        {
            Salary *= 0.1;
        }

        public string GetEmpDetails()
        {
       
            return $"Employee ID: {Id}, Name: {Name}, Salary: {Salary:C}";
        }

      
        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to deserialize a JSON string to an Employee object
        public static Employee DeserializeFromJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<Employee>(jsonString);
        }
    }

    class NewProgram
    {
        static void Main()
        {
            // Create an Employee object
            Employee employee = new Employee
            {
                Name = "John Doe",
                Salary = 50000.0,
                Id = 123
            };

         
            string json = employee.SerializeToJson();
            Console.WriteLine("Serialized JSON:\n" + json);

            Employee deserializedEmployee = Employee.DeserializeFromJson(json);

          
            Console.WriteLine("\nDeserialized Employee:");
            Console.WriteLine(deserializedEmployee.GetEmpDetails());

            deserializedEmployee.CalculateSalary();
            Console.WriteLine("\nAfter salary calculation:");
            Console.WriteLine(deserializedEmployee.GetEmpDetails());
        }
    }
}
