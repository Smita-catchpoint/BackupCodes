//using System;
//using System.Collections.Generic;
//using Newtonsoft.Json;

//namespace CustomSerializer
//{
//    public class StudentDetails
//    {
//        public Dictionary<string, string> Details { get; set; }

//        public StudentDetails()
//        {
//            Details = new Dictionary<string, string>();
//        }

//    }
//    class StudentMain
//    {
//        static void Main(string[] args)
//        {
//            StudentDetails sd = new StudentDetails();
//            sd.Details.Add("Name", "smita");
//            sd.Details.Add("Age", "20");
//            sd.Details.Add("Branch", "IT");

//            Console.WriteLine("/n Values:");
//            foreach (var item in sd.Details.Keys)
//            {
//                Console.WriteLine(item);

//            }
//            Console.WriteLine("/n keys:");

//            foreach (var item in sd.Details.Values)
//            {
//                Console.WriteLine(item);

//            }

//            //serialize
//            string json= JsonConvert.SerializeObject(sd);
//            Console.WriteLine("\nSerialized Directory" );
//           Console.WriteLine(json);

//            //deserialize
//            StudentDetails deserializedsd = JsonConvert.DeserializeObject<StudentDetails>(json);
//            Console.WriteLine("\nDeserialized Directory");
//            //Console.WriteLine(deserializedsd);
//            /* output of above line: 
//             Deserialized Directory
//            CustomSerializer.StudentDetails*/


//            Console.WriteLine("/n keysValue:");
//            foreach (var item in sd.Details)
//            {
//                Console.WriteLine($"{item.Key}:{item.Value}");
//            }

//        }
//    }

//}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CustomSerializer
{
    public class StudentDetails
    {
        public Dictionary<int, string> Details { get; set; }

        public StudentDetails()
        {
            Details = new Dictionary<int, string>();
        }

    }
    class StudentMain
    {
        static void Main(string[] args)
        {
            StudentDetails sd = new StudentDetails();
            sd.Details.Add(1, "smita");
            sd.Details.Add(2, "20");
            sd.Details.Add(3, "IT");

            Console.WriteLine("Values:");
            foreach (var item in sd.Details.Keys)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("keys:");

            foreach (var item in sd.Details.Values)
            {
                Console.WriteLine(item);

            }

            //serialize
            string json = JsonConvert.SerializeObject(sd);
            Console.WriteLine("\nSerialized Directory");
            Console.WriteLine(json);

            //deserialize
            StudentDetails deserializedsd = JsonConvert.DeserializeObject<StudentDetails>(json);
            Console.WriteLine("\nDeserialized Directory");
            //Console.WriteLine(deserializedsd);
            /* output of above line: 
             Deserialized Directory
            CustomSerializer.StudentDetails*/


            Console.WriteLine("/n keysValue:");
            foreach (var item in sd.Details)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

        }
    }

}