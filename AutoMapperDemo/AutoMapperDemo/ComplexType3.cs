using AutoMapper;
using AutoMapperDemo;

namespace AutoMapperDemo
{

    public class Address7
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Employee7
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address7 Address { get; set; }
    }
    public class AddressDTO7
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeDTO7
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public AddressDTO7 AddressDTO { get; set; }
    }

    public class MapperConfig7
    {
        public static Mapper InitializeAutomapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address7, AddressDTO7>();
                cfg.CreateMap<Employee7, EmployeeDTO7>()
                .ForMember(dest => dest.AddressDTO, act => act.MapFrom(src => src.Address)); 
            

        });

            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class ComplexType3
    {
        static void Main(string[] args)
        {

            Address7 empAddres = new Address7()
            {
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };

            Employee7 emp1 = new Employee7
            {
                Name = "James",
                Salary = 20000,
                Department = "IT",
                Address = empAddres
            };
            //Initialize the AutoMapper
            var mapper = MapperConfig7.InitializeAutomapper();

            //var empDTO2 = mapper.Map<EmployeeDTO7>(emp1);
            var empDTO2 = mapper.Map<Employee7, EmployeeDTO7>(emp1);


            Console.WriteLine("Name:" + empDTO2.Name + ", Salary:" + empDTO2.Salary + ", Department:" + empDTO2.Department);
            Console.WriteLine("City:" + empDTO2.AddressDTO.City + ", State:" + empDTO2.AddressDTO.State + ", Country:" + empDTO2.AddressDTO.Country);
            Console.ReadLine();
        }
    }
}