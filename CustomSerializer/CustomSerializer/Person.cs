using System;
using Newtonsoft.Json;

namespace CustomSerializer
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
     class Persons
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Name = "Anuja",
                Age = 21,
                Address = new Address { Street = "6th cross Main st", City = "Nashik" }

            };

            string json =JsonConvert.SerializeObject(p);
            Console.WriteLine("Serialized Object:");
            Console.WriteLine(json);
           

            string s = "{\"Name\": \"Anuja\",\"Age\": \"21\", \"Address\":{\"Street\": \"6th cross Main st\", \"City\": \"Nashik\"}}";
            Person de =JsonConvert.DeserializeObject<Person>(s);
            //Console.WriteLine(de);
            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine($"Name:{de.Name},Age :{de.Age}");
            //Console.WriteLine($"Street: {de.Address.Street}, City:{de.Address.City}");
            Console.WriteLine($"Address: {de.Address.Street},{de.Address.City}");

        }



    }
}
