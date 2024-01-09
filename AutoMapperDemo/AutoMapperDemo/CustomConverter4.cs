//using AutoMapper;
//using System;

//public class Employee
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public decimal AnnualSalary { get; set; }
//}

//public class EmployeeDto
//{
//    public string FullName { get; set; }
//    public decimal MonthlySalary { get; set; }
//}

//public class EmployeeToEmployeeDtoConverter : ITypeConverter<Employee, EmployeeDto>
//{
//    public EmployeeDto Convert(Employee source, EmployeeDto destination, ResolutionContext context)
//    {

//        var fullName = $"{source.FirstName} {source.LastName}";
//        var monthlySalary = ConvertAnnualToMonthlySalary(source.AnnualSalary);

//        return new EmployeeDto
//        {
//            FullName = fullName,
//            MonthlySalary = monthlySalary
//        };
//    }

//    private decimal ConvertAnnualToMonthlySalary(decimal annualSalary)
//    {

//        const int monthsInYear = 12;
//        return annualSalary / monthsInYear;
//    }
//}

//class CustomConverter4
//{
//    static void Main()
//    {

//        var configuration = new MapperConfiguration(cfg =>
//        {
//            cfg.CreateMap<Employee, EmployeeDto>().ConvertUsing<EmployeeToEmployeeDtoConverter>();
//        });


//        IMapper mapper = configuration.CreateMapper();


//        var employee = new Employee
//        {
//            FirstName = "John",
//            LastName = "Doe",
//            AnnualSalary = 60000
//        };


//        var employeeDto = mapper.Map<EmployeeDto>(employee);


//        Console.WriteLine($"FullName: {employeeDto.FullName}");
//        Console.WriteLine($"MonthlySalary: {employeeDto.MonthlySalary}");
//    }
//}

using AutoMapper;


public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
}

public class EmployeeDto
{
    public string FullName { get; set; }
    public decimal MonthlySalary { get; set; }
}

public class EmployeeToEmployeeDtoConverter : ITypeConverter<Employee, EmployeeDto>
{
    public EmployeeDto Convert(Employee source, EmployeeDto destination, ResolutionContext context)
    {
        // Custom mapping logic
        var fullName = $"{source.FirstName} {source.LastName}";
        var monthlySalary = ConvertAnnualToMonthlySalary(source.AnnualSalary);

        return new EmployeeDto
        {
            FullName = fullName,
            MonthlySalary = monthlySalary
        };
    }

    private decimal ConvertAnnualToMonthlySalary(decimal annualSalary)
    {
        // Custom logic to convert annual salary to monthly salary
        const int monthsInYear = 12;
        return annualSalary / monthsInYear;
    }
}

class CustomConverter4
{
    static void Main()
    {
        // AutoMapper configuration
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Employee, EmployeeDto>().ConvertUsing<EmployeeToEmployeeDtoConverter>();
        });

        
        IMapper mapper = configuration.CreateMapper();

       
        var employees = new List<Employee>
        {
            new Employee { FirstName = "John", LastName = "Doe", AnnualSalary = 60000 },
            new Employee { FirstName = "Jane", LastName = "Smith", AnnualSalary = 75000 }
        };

        
        var employeeDtos = mapper.Map<List<EmployeeDto>>(employees);

        
        foreach (var employeeDto in employeeDtos)
        {
            Console.WriteLine($"FullName: {employeeDto.FullName}");
            Console.WriteLine($"MonthlySalary: {employeeDto.MonthlySalary}");
            Console.WriteLine();
        }
    }
}
