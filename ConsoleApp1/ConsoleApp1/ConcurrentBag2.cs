using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConcurrentBag2
    {
        static void Main(string[] args)
        {
            
            ConcurrentBag<Student> bag = new ConcurrentBag<Student>();

            
            bag.Add(new Student() { ID = 101, Name = "Anurag", Branch = "CSE" });
            bag.Add(new Student() { ID = 102, Name = "Mohanty", Branch = "CSE" });
            bag.Add(new Student() { ID = 103, Name = "Sambit", Branch = "ETC" });

            //Accesing all the Elements of ConcurrentBag using For Each Loop
            Console.WriteLine("ConcurrentBag Elements");
            foreach (var item in bag)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Branch: {item.Branch}");
            }

            Console.ReadKey();
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Branch { get; set; }
        }
    }
}
