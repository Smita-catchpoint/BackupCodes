using AutoMapper;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class PersonViewModel
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

public class PersonToPersonViewModelConverter : ITypeConverter<Person, PersonViewModel>
{
    public PersonViewModel Convert(Person source, PersonViewModel destination, ResolutionContext context)
    {
        // Custom mapping logic
        var fullName = $"{source.FirstName} {source.LastName}";
        var age = CalculateAge(source.DateOfBirth);

        return new PersonViewModel
        {
            FullName = fullName,
            Age = age
        };
    }

    private int CalculateAge(DateTime dateOfBirth)
    {

        var today = DateTime.Today;
        //Console.WriteLine(today);
        var age = today.Year - dateOfBirth.Year;
        //Console.WriteLine(age);



        if (dateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}

class CustomConverter2
{
    static void Main()
    {

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Person, PersonViewModel>().ConvertUsing<PersonToPersonViewModelConverter>();
        });


        IMapper mapper = configuration.CreateMapper();


        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 5, 15)
        };


        var personViewModel = mapper.Map<PersonViewModel>(person);


        Console.WriteLine($"FullName: {personViewModel.FullName}");
        Console.WriteLine($"Age: {personViewModel.Age}");


    }
}
