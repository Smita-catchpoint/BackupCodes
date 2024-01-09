using AutoMapper;
using System.Linq;

namespace AutoMapperDemo
{

    public class MyAddress
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class TheEmployee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public MyAddress Address { get; set; }
    }
    public class TheEmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }


    public class MyMapperConfig
    {
        public static Mapper InitializeAutomapper()
        {

            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TheEmployee, TheEmployeeDTO>()

               .ForMember(dest => dest.City, act => act.MapFrom(src => src.Address.City))

               .ForMember(dest => dest.State, act => act.MapFrom(src => src.Address.State))

               .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Address.Country));
            });


            var mapper = new Mapper(config);
            return mapper;
        }
        internal class ComplexToPrimitive
        {
            static void Main(string[] args)
            {
               
                MyAddress empAddres = new MyAddress()
                {
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India"
                };
            
                TheEmployee emp = new TheEmployee
                {
                    Name = "James",
                    Salary = 20000,
                    Department = "IT",
                    Address = empAddres
                };
              
                var mapper = MyMapperConfig.InitializeAutomapper();
            
                var empDTO = mapper.Map<TheEmployeeDTO>(emp);
         
                //var empDTO = mapper.Map<Employee, EmployeeDTO>(emp);
                Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
                Console.WriteLine("City:" + empDTO.City + ", State:" + empDTO.State + ", Country:" + empDTO.Country);
                Console.ReadLine();
            }
        }

    }
    }
