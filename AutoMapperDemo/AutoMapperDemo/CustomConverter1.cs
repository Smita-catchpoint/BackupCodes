using AutoMapper;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductDto
{
    public string DisplayName { get; set; }
}

public class ProductDtoConverter : ITypeConverter<Product, ProductDto>
{
    public ProductDto Convert(Product source, ProductDto destination, ResolutionContext context)
    {
        // Custom mapping logic
        string displayPrefix = source.Price >= 100 ? "Premium" : "Standard";

        return new ProductDto
        {
            DisplayName = $"{displayPrefix} - {source.Name} (ID: {source.ProductId})"
        };
    }
}

class CustomConverter1
{
    static void Main()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDto>().ConvertUsing<ProductDtoConverter>();
        });


        IMapper mapper = configuration.CreateMapper();


        var product = new Product
        {
            ProductId = 456,
            Name = "Widget",
            Price = 120.00m
        };

        var productDto = mapper.Map<ProductDto>(product);

        // Display the result
        Console.WriteLine($"DisplayName: {productDto.DisplayName}");

    }
}
