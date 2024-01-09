using System;
using System.Collections.Generic;

using AutoMapper;
namespace AutoMapperDemo

{
    //no need do initialize again an again >just initialize once
    public class MapperConfig22
    {
        public static bool IsInitialized;
        private static Mapper mapper;

        public static Mapper InitializeAutomapper()
        {
            //checking initialized or not
            if (IsInitialized == false)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Employee, Employee2>();
                    cfg.CreateMap<Employee, Employee3>();

                });

                var mapper = new Mapper(config);
                IsInitialized = true;
            }

            return mapper;
        }

        public class FileName
        {
            public static void Main(string[] args)
            {

                Employee emp = new Employee
                {
                    Name = "James",
                    Salary = 20000,
                    Address = "London",
                    Department = "IT"
                };

                //Initializing AutoMapper
                var mapper = MapperConfig22.InitializeAutomapper();


                var emp11 = mapper.Map<Employee, Employee3>(emp);
                Console.WriteLine("Name: " + emp11.Name + ", Salary: " + emp11.Salary + ", Address: " + emp11.Address + ", Department: " + emp11.Department);


                var emp22 = mapper.Map<Employee, Employee2>(emp);

                Console.WriteLine("Name: " + emp22.Name + ", Salary: " + emp22.Salary + ", Address: " + emp22.Address + ", Department: " + emp22.Department);
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

        public class Employee3
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public string Address { get; set; }
            public string Department { get; set; }
        }

    }
}


