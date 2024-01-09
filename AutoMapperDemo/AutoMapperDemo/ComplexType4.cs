
//using AutoMapper;
//using AutoMapperDemo;

//namespace AutoMapperDemo
//{

//    public class Address4
//    {
//        public string City { get; set; }
//        public string State { get; set; }
//        public string Country { get; set; }
//    }

//    public class Employee4
//    {
//        public string Name { get; set; }
//        public int Salary { get; set; }
//        public string Department { get; set; }
//        public Address4 Address { get; set; }
//    }
//    public class AddressDTO4
//    {    public string EmpCity { get; set; }
//        public string EmpState { get; set; }
//        public string Country { get; set; }
//    }
//    public class EmployeeDTO4
//    {
//        public string Name { get; set; }
//        public int Salary { get; set; }
//        public string Department { get; set; }
//        public AddressDTO4 AddressDTO { get; set; }
//    }

//    public class MapperConfig77
//    {
//        public static Mapper InitializeAutomapper()
//        {

//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Address4, AddressDTO4>();
//                cfg.CreateMap<Employee4, EmployeeDTO4>()
//                .ForMember(dest => dest.AddressDTO, act => act.MapFrom(src => src.Address));


//            });

//            var mapper = new Mapper(config);
//            return mapper;
//        }
//    }

//    public class ComplexType4
//    {
//        static void Main(string[] args)
//        {

//            Address4 empAddres = new Address4()
//            {
//                City = "Mumbai",
//                State = "Maharashtra",
//                Country = "India"
//            };

//            Employee4 emp2 = new Employee4
//            {
//                Name = "James",
//                Salary = 20000,
//                Department = "IT",
//                Address = empAddres
//            };
//            //Initialize the AutoMapper
//            var mapper = MapperConfig77.InitializeAutomapper();

//            //var empDTO2 = mapper.Map<EmployeeDTO7>(emp1);
//            var empDTO2 = mapper.Map<Employee4, EmployeeDTO4>(emp2);


//            Console.WriteLine("Name:" + empDTO2.Name + ", Salary:" + empDTO2.Salary + ", Department:" + empDTO2.Department);
//            Console.WriteLine("City:" + empDTO2.AddressDTO.EmpCity + ", State:" + empDTO2.AddressDTO.EmpState + ", Country:" + empDTO2.AddressDTO.Country);
//            Console.ReadLine();
//        }
//    }
//}



using AutoMapper;
using AutoMapperDemo;

namespace AutoMapperDemo
{

    public class Address4
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Employee4
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address4 Address { get; set; }
    }
    public class AddressDTO4
    {
        public string EmpCity { get; set; }
        public string EmpState { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeDTO4
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public AddressDTO4 AddressDTO { get; set; }
    }

    public class MapperConfig77
    {
        public static Mapper InitializeAutomapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address4, AddressDTO4>()
                .ForMember(dest => dest.EmpCity, act => act.MapFrom(src => src.City))
                .ForMember(dest => dest.EmpState, act => act.MapFrom(src => src.State)) ;

                cfg.CreateMap<Employee4, EmployeeDTO4>()
                .ForMember(dest => dest.AddressDTO, act => act.MapFrom(src => src.Address));


            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class ComplexType4
    {
        static void Main(string[] args)
        {

            Address4 empAddres = new Address4()
            {
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };

            Employee4 emp2 = new Employee4
            {
                Name = "James",
                Salary = 20000,
                Department = "IT",
                Address = empAddres
            };
            //Initialize the AutoMapper
            var mapper = MapperConfig77.InitializeAutomapper();

            //var empDTO2 = mapper.Map<EmployeeDTO7>(emp1);
            var empDTO2 = mapper.Map<Employee4, EmployeeDTO4>(emp2);


            Console.WriteLine("Name:" + empDTO2.Name + ", Salary:" + empDTO2.Salary + ", Department:" + empDTO2.Department);
            Console.WriteLine("City:" + empDTO2.AddressDTO.EmpCity + ", State:" + empDTO2.AddressDTO.EmpState + ", Country:" + empDTO2.AddressDTO.Country);
            Console.ReadLine();
        }
    }
}