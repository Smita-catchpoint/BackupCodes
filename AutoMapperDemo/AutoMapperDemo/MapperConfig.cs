using AutoMapper;
namespace AutoMapperDemo
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
             
                cfg.CreateMap<Employee, Employee2>();
              
            });

            
            var mapper = new Mapper(config);
            return mapper;
        }

        class Program
        {
            static void Main(string[] args)
            {
                
                Employee emp = new Employee
                {
                    Name = "James",
                    Salary = 20000,
                    Address = "London",
                    Department = "IT"
                };

                //Initializing AutoMapper
                var mapper = MapperConfig.InitializeAutomapper();

             
                var emp1 = mapper.Map<Employee2>(emp);
                Console.WriteLine("Name: " + emp1.Name + ", Salary: " + emp1.Salary + ", Address: " + emp1.Address + ", Department: " + emp1.Department);


                var emp2 = mapper.Map<Employee, Employee2>(emp);

                Console.WriteLine("Name: " + emp2.Name + ", Salary: " + emp2.Salary + ", Address: " + emp2.Address + ", Department: " + emp2.Department);
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
}


