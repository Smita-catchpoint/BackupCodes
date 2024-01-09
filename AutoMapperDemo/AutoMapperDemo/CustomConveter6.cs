//using System;
//using AutoMapper;
//namespace AutoMapperDemo
//{
//    public class Person5
//    {
//        public string Name { get; set; }
//        public DateTime BirthDate { get; set; }
//    }

//    public class PersonDto
//    {
//        public string Name { get; set; }
//        public string FormattedBirthDate { get; set; }
//    }

//    public class CustomPersonConverter : ITypeConverter<Person5, PersonDto>
//    {
//        public PersonDto Convert(Person5 source, PersonDto destination, ResolutionContext context)
//        {
//            // Access source and destination type information
//            var sourceType = context.Parent.SourceType;
//            var destinationType = context.DestinationType;

//            Console.WriteLine($"Source Type: {sourceType}, Destination Type: {destinationType}");

//            // Custom logic for formatting the date
//            var formattedBirthDate = source.BirthDate.ToString("yyyy-MM-dd");

//            // Create the destination object
//            var personDto = new PersonDto
//            {
//                Name = source.Name,
//                FormattedBirthDate = formattedBirthDate
//            };

//            return personDto;
//        }
//    }

//    class CustomConveter6
//    {
//        static void Main()
//        {
//            // Configure AutoMapper
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Person5, PersonDto>().ConvertUsing<CustomPersonConverter>();
//            });

//            IMapper mapper = config.CreateMapper();

//            var person5 = new Person5
//            {
//                Name = "John Doe",
//                BirthDate = new DateTime(1990, 1, 1)
//            };

//            // Use AutoMapper to map Person to PersonDto using the CustomPersonConverter
//            var personDto = mapper.Map<PersonDto>(person5);

//            Console.WriteLine($"Mapped PersonDto: {personDto.Name}, {personDto.FormattedBirthDate}");
//        }
//    }
//}