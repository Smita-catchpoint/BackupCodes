using Newtonsoft.Json;
namespace CustomSerializer
{
    internal class Demo2
    {
        static void Main(string[] args)
        {
            Product p1 = new Product
            {
                Name = "Product 1",
                Price = 99.95m,
                ExpiryDate = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc),
            };
            Product p2 = new Product
            {
                Name = "Product 2",
                Price = 12.50m,
                ExpiryDate = new DateTime(2009, 7, 31, 0, 0, 0, DateTimeKind.Utc),
            };

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);

            Console.Write( "serialized object: ");
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            

            Console.WriteLine("Deserialized object: ");
            List<Product> product = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach(Product prod in product)
            {
                Console.WriteLine($"Name:{prod.Name}, Price:{prod.Price},ExpiryDate:{prod.ExpiryDate}");
            }


            Console.WriteLine($"count: {products.Count}");
            Product p = products[0];
            Console.WriteLine(p.Name);
            Console.WriteLine();

            Console.WriteLine("string json to object:");
            string json2 = @"[
               {
                'Name': 'Product 1',
                'ExpiryDate': '2000-12-29T00:00Z',
                'Price': 99.95,
                'Sizes': null
               },
              {
                'Name': 'Product 2',
                'ExpiryDate': '2009-07-31T00:00Z',
                'Price': 12.50,
                'Sizes': null
              }
              ]";

            List<Product> pro = JsonConvert.DeserializeObject<List<Product>>(json2);


            foreach (Product prod in pro)
            {
                Console.WriteLine($"Name:{prod.Name}, Price:{prod.Price},ExpiryDate:{prod.ExpiryDate}");
            }

        }
    }


}