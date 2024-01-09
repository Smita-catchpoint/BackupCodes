using AutoMapper;

namespace AutoMapperDemo
{
    public class Employeee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class MyAddres
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public MyAddres Address { get; set; }
    }
    public class MapperConfigg
    {
        public static Mapper InitializeAutomapper()
        {   //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg => {
                //Configuring Employeee and EmployeeeDTO
                cfg.CreateMap<Employeee, EmployeeeDTO>()
                .ForMember(dest => dest.Address, act => act.MapFrom(src => new MyAddres()
                {
                    City = src.City,
                    State = src.State,
                    Country = src.Country
                }));
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
    internal class PrimitiveToComplex
    {
        static void Main(string[] args)
        {
          //source object
            Employeee emp = new Employeee
            {
                Name = "James",
                Salary = 20000,
                Department = "IT",
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };

            //Initializing AutoMapper
            var mapper = MapperConfigg.InitializeAutomapper();

            //Specify the Destination Type and to The Map Method pass the Source Object
            var empDTO = mapper.Map<EmployeeeDTO>(emp);
        
            //var empDTO = mapper.Map<Employeee, EmployeeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
            Console.WriteLine("City:" + empDTO.Address.City + ", State:" + empDTO.Address.State + ", Country:" + empDTO.Address.Country);
            Console.ReadLine();
        }
    }

}

