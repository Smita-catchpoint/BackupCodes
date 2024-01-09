using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class CQueue
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<Student> students = new ConcurrentQueue<Student>();
            students.Enqueue(new Student() { ID = 101, Name = "Anurag", Branch = "CSE" });
            students.Enqueue(new Student() { ID = 102, Name = "Mohanty", Branch = "CSE" });
            students.Enqueue(new Student() { ID = 103, Name = "Sambit", Branch = "ETC" });

            foreach (var item in students)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name},Branch: {item.Branch}" );
            }
        }


        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Branch { get; set; }


        }
    }
}
