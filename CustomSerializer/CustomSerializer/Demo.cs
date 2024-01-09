using Newtonsoft.Json;
using System;

namespace CustomSerializer
{
    internal class Demo
    {
        static void Main(string[] args)
        {
            Product product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product, Formatting.Indented);
            Console.WriteLine(output);
            Console.WriteLine();

            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            //Console.WriteLine(deserializedProduct.Name);
            //Console.WriteLine(deserializedProduct.ExpiryDate);
            //Console.WriteLine(deserializedProduct.Price);
            Console.WriteLine($"Name:{deserializedProduct.Name}, Price: {deserializedProduct.Price}, ExpiryDate:{deserializedProduct.ExpiryDate}");

            foreach (string size in deserializedProduct.Sizes)
            {
                Console.WriteLine(size);
            }


        }
    }

    class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
