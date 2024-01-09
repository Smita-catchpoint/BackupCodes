using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CustomSerializer
{

    public class StudentInfo
    {
        public Dictionary<string, StudentDetail> Students { get; set; }//property

        public StudentInfo()
        {
            Students = new Dictionary<string, StudentDetail>();//initializing with empty dictionary
        }
    }
    public class StudentDetail
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public int Rank { get; set; }

    }
    public class Program
    {
        static void Main(string[] args)
        {   //create>instance of StudentDetail & initialize their properties.
            StudentDetail s1 = new StudentDetail { Name = "Anuja", RollNumber = 101, Rank = 1 };
            StudentDetail s2 = new StudentDetail { Name = "smitaraj", RollNumber = 102, Rank = 2 };
            StudentDetail s3 = new StudentDetail { Name = "Amar", RollNumber = 103, Rank = 3 };

            StudentInfo sf = new StudentInfo();
            //Tostring >to convert key (RollNumber ) to string
            sf.Students.Add(s1.RollNumber.ToString(), s1);
            sf.Students.Add(s2.RollNumber.ToString(), s2);
            sf.Students.Add(s3.RollNumber.ToString(), s3);


            //serialize
            string json = JsonConvert.SerializeObject(sf);
            Console.WriteLine("\nSerialized StudentInfo");
            Console.WriteLine(json);


            //deserialize
            StudentInfo deserializedInfo = JsonConvert.DeserializeObject<StudentInfo>(json);
            Console.WriteLine("\nderialized StudentInfo");
            //Console.WriteLine(deserializedInfo);

            foreach (var item in deserializedInfo.Students.Values)
            {
                Console.WriteLine($"Name:{item.Name}, RollNumber:{item.RollNumber}, Rank:{item.Rank}");
            }


        }

    }
}


//using System.Collections.Generic;
//using Newtonsoft.Json;

//namespace CustomSerializer
//{

//    public class StudentInfo
//    {
//        public Dictionary<int, StudentDetail> Students { get; set; }//property

//        public StudentInfo()
//        {
//            Students = new Dictionary<int, StudentDetail>();//initializing with empty dictionary
//        }
//    }
//    public class StudentDetail
//    {
//        public string Name { get; set; }
//        public int RollNumber { get; set; }
//        public int Rank { get; set; }

//    }
//    public class Program
//    {
//        static void Main(string[] args)
//        {   //create>instance of StudentDetail & initialize their properties.
//            StudentDetail s1 = new StudentDetail { Name = "Anuja", RollNumber = 101, Rank = 1 };
//            StudentDetail s2 = new StudentDetail { Name = "smitaraj", RollNumber = 102, Rank = 2 };
//            StudentDetail s3 = new StudentDetail { Name = "Amar", RollNumber = 103, Rank = 3 };

//            StudentInfo sf = new StudentInfo();

//            sf.Students.Add(s1.RollNumber, s1);
//            sf.Students.Add(s2.RollNumber, s2);
//            sf.Students.Add(s3.RollNumber,s3);


//            //serialize
//            string json = JsonConvert.SerializeObject(sf,Formatting.Indented);
//            Console.WriteLine("\nSerialized StudentInfo");
//            Console.WriteLine(json);


//            //deserialize
//            StudentInfo deserializedInfo = JsonConvert.DeserializeObject<StudentInfo>(json);
//            Console.WriteLine("\nderialized StudentInfo");
//            //Console.WriteLine(deserializedInfo);

//            foreach (var item in deserializedInfo.Students.Values)
//            {
//                Console.WriteLine($"Name:{item.Name}, RollNumber:{item.RollNumber}, Rank:{item.Rank}");
//            }


//        }

//    }
//}
