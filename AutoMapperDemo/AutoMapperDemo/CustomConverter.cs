using AutoMapper;
using System;

public class Order
{
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
}

public class OrderDto
{
    public string DisplayInfo { get; set; }
}

class CustomConveter

{
    static void Main()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Order, OrderDto>()
               .ConvertUsing(order => new OrderDto
               {
                   DisplayInfo = $"Order #{order.OrderId} - Total: ${order.TotalAmount} - Date: {order.OrderDate.ToString("yyyy-MM-dd")}"
               });
        });


        IMapper mapper = configuration.CreateMapper();


        var order = new Order
        {
            OrderId = 123,
            TotalAmount = 99.99m,
            OrderDate = DateTime.Now
        };


        var orderDto = mapper.Map<OrderDto>(order);


        Console.WriteLine($"DisplayInfo: {orderDto.DisplayInfo}");


    }
}
