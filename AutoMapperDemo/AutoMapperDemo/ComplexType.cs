using AutoMapper;

namespace AutoMapperDemo
{
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class Employee44
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address Address { get; set; }
    }
    public class AddressDTO
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeDTO
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public string Department { get; set; }
            public AddressDTO Address { get; set; }
        }
    

    public class MapperConfig44
        {
            public static Mapper InitializeAutomapper()
            {

            var config = new MapperConfiguration(cfg => {
              
                cfg.CreateMap<Address, AddressDTO>();
                cfg.CreateMap<Employee44, EmployeeDTO>();
            });

            var mapper = new Mapper(config);
                return mapper;
            }
        }
    

    class ComplexType
        {
            static void Main(string[] args)
            {
          
                Address empAddres = new Address()
                {
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India"
                };

                Employee44 emp = new Employee44
                {
                    Name = "James",
                    Salary = 20000,
                    Department = "IT",
                    Address = empAddres
                };

                //Initialize the AutoMapper
                var mapper = MapperConfig44.InitializeAutomapper();

                var empDTO = mapper.Map<EmployeeDTO>(emp);

                //var empDTO = mapper.Map<Employee, EmployeeDTO>(emp);

                Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
                Console.WriteLine("City:" + empDTO.Address.City + ", State:" + empDTO.Address.State + ", Country:" + empDTO.Address.Country);
                Console.ReadLine();
            }
        }
    }

