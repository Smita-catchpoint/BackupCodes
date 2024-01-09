////using Newtonsoft.Json;


////namespace CustomSerializer
////{
////    class MyClass
////    {

////        public string Name { get; set; }
////        public string City { get; set; }
////        public string Country { get; set; }

////        [JsonIgnore]
////        public int Age { get; set; }
////        [JsonIgnore]
////        public double salary { get; set; }
////        internal class NewProgram2
////        {
////            static void Main(string[] args)
////            {
////                MyClass myClass = new MyClass
////                {
////                    Name = "jonh",
////                    City = "Pune",
////                    Country = "INDIA",
////                    Age = 25,
////                    salary = 25000.0

////                };

////                string json = JsonConvert.SerializeObject(myClass, Formatting.Indented);
////                Console.WriteLine(json);


////            }
////        }
////    }
////}


//using Newtonsoft.Json;


//namespace CustomSerializer
//{
//    class MyClass
//    {
//        [JsonProperty("FullName")]
//        public string Name { get; set; }
//        [JsonProperty("City")]
//        public string City { get; set; }

//        [JsonProperty("Country")]
//        public string Country { get; set; }

//        [JsonIgnore]
//        public int Age { get; set; }
//        [JsonIgnore]
//        public double salary { get; set; }
//        internal class NewProgram2
//        {
//            static void Main(string[] args)
//            {
//                MyClass myClass = new MyClass
//                {
//                    Name = "jonh",
//                    City = "Pune",
//                    Country = "INDIA",
//                    Age = 25,
//                    salary = 25000.0

//                };

//                string json = JsonConvert.SerializeObject(myClass, Formatting.Indented);
//                Console.WriteLine(json);

//                MyClass obj = JsonConvert.DeserializeObject<MyClass>(json);
//                Console.WriteLine($"Name: {obj.Name},City:{obj.City},Country:{obj.Country},Age:{obj.Age},salary:{obj.salary}");

//                Console.WriteLine();




//            }
//        }
//    }
//}


using Newtonsoft.Json;
namespace CustomSerializer
{
    class MyClass
    {
     
        public string Name { get; set; }
        [JsonProperty("MyCity")]
        public string City { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonIgnore]
        public int Age { get; set; }
        [JsonIgnore]
        public double salary { get; set; }
        internal class NewProgram2
        {
            static void Main(string[] args)
            {
                
                string json2 = @"
               {
                'Name': 'Product 1',
                'MyCity': 'Pune',
                'Country':'India',
                'Age': 23,
                 'salary': 2300.0
                }";

                MyClass obj2 = JsonConvert.DeserializeObject<MyClass>(json2);
                Console.WriteLine($"Name: {obj2.Name},City:{obj2.City},Country:{obj2.Country},Age:{obj2.Age},salary:{obj2.salary}");


            }
        }
    }
}
