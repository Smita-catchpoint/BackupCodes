using AutoMapper;
using System;
using System.Collections.Generic;
namespace AutoMapperDemo
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public string DisplayDate { get; set; }
        public List<string> ItemSummaries { get; set; }
    }

    public class OrderToOrderDtoConverter : ITypeConverter<Order, OrderDto>
    {
        public OrderDto Convert(Order source, OrderDto destination, ResolutionContext context)
        {
            // Custom mapping logic
            var displayDate = source.OrderDate.ToString("yyyy-MM-dd");
            var itemSummaries = MapOrderItems(source.Items);

            return new OrderDto
            {
                OrderId = source.OrderId,
                DisplayDate = displayDate,
                ItemSummaries = itemSummaries
            };
        }

        private List<string> MapOrderItems(List<OrderItem> items)
        {
            // Custom logic to map OrderItem objects to a simplified format
            return items.Select(item =>
                $"{item.Quantity} x {item.ProductName} at ${item.PricePerUnit} each")
                .ToList();
        }
    }

    class CostumConverter3
    {
        static void Main()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>().ConvertUsing<OrderToOrderDtoConverter>();
            });


            IMapper mapper = configuration.CreateMapper();


            var order = new Order
            {
                OrderId = 789,
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
            {
                new OrderItem { ProductName = "Widget", Quantity = 2, PricePerUnit = 10.99m },
                new OrderItem { ProductName = "Gadget", Quantity = 1, PricePerUnit = 29.99m }
            }
            };


            var orderDto = mapper.Map<OrderDto>(order);

            Console.WriteLine($"OrderId: {orderDto.OrderId}");
            Console.WriteLine($"DisplayDate: {orderDto.DisplayDate}");
            Console.WriteLine("Item Summaries:");
            foreach (var itemSummary in orderDto.ItemSummaries)
            {
                Console.WriteLine($"  {itemSummary}");
            }

        }
    }
}