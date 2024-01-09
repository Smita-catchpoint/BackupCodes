using System;
using Newtonsoft.Json;


namespace CustomSerializer
{
    internal class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
    class Student
    {
        static void Main(string[] args)
        {
            Students s = new Students { Name = "smita", Age = 30 };
            String json = JsonConvert.SerializeObject(s);
            Console.WriteLine(json);


            //string jsonToDeserialize = json;
            //  Students desirializedstudents =JsonConvert.DeserializeObject<Students>(json);

            string d = "{\"Name\":\"smita\",\"Age\":25}";
            Students desirializedstudents =JsonConvert.DeserializeObject<Students>(d);
           Console.WriteLine($"Name:{ desirializedstudents.Name}, Age:{desirializedstudents.Age}");
            // Console.WriteLine(desirializedstudents);

        }
    }
}
