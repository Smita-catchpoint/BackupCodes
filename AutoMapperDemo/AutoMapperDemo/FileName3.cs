using AutoMapper;
using System;

namespace AutoMapperDemo
{
    public class Empl1
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class Empl2
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class Empl3
    {
        public string FullName { get; set; }
        public int MonthlySalary { get; set; }
        public string Residence { get; set; }
        public string Dept { get; set; }
    }

    public class MapperConfig4
    {
        private static IMapper mapperInstance2;

        public static IMapper InitializeAutomapper2()
        {
           // if (mapperInstance2 == null)
           // {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Empl1, Empl2>();
                    cfg.CreateMap<Empl1, Empl3>()
                       .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                       .ForMember(dest => dest.MonthlySalary, opt => opt.MapFrom(src => src.Salary))
                       .ForMember(dest => dest.Residence, opt => opt.MapFrom(src => src.Address))
                       .ForMember(dest => dest.Dept, opt => opt.MapFrom(src => src.Department));
                });

                 mapperInstance2 = new Mapper(config);
            //}

            return mapperInstance2;
        }
    }

    public class FileName3
    {
        static void Main(string[] args)
        {
            Empl1 emp1 = new Empl1
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            // Initializing AutoMapper
            var mapper = MapperConfig4.InitializeAutomapper2();

            var emp11 = mapper.Map<Empl2>(emp1);

            Console.WriteLine($"Name: {emp11.Name}, Salary: {emp11.Salary}, Address: {emp11.Address}, Department: {emp11.Department}");

            var emp22 = mapper.Map<Empl1, Empl3>(emp1);

            Console.WriteLine($"FullName: {emp22.FullName}, MonthlySalary: {emp22.MonthlySalary}, Residence: {emp22.Residence}, Department: {emp22.Dept}");

            Console.ReadLine();
        }
    }
}