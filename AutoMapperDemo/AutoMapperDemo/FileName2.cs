
using AutoMapper;
using System;

namespace AutoMapperDemo
{
    public class Emp1
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class Emp2
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class Emp3
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class MapperConfig3
    {
        private static IMapper mapperInstance;

        public static IMapper InitializeAutomapper()
        {
           if (mapperInstance == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Emp1, Emp2>();
                    cfg.CreateMap<Emp1, Emp3>();
                });

                mapperInstance = new Mapper(config);
            }

            return mapperInstance;
        }
    }

    public class Program2
    {
        static void Main(string[] args)
        {
            Emp1 emp = new Emp1
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            // Initializing AutoMapper
            var mapper = MapperConfig3.InitializeAutomapper();

            var emp11 = mapper.Map<Emp2>(emp);

            Console.WriteLine($"Name: {emp11.Name}, Salary: {emp11.Salary}, Address: {emp11.Address}, Department: {emp11.Department}");

            var emp22 = mapper.Map<Emp1, Emp3>(emp);

            Console.WriteLine($"Name: {emp22.Name}, Salary: {emp22.Salary}, Address: {emp22.Address}, Department: {emp22.Department}");

            Console.ReadLine();
        }
    }
}

