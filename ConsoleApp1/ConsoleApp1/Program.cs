using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<int, Student> dictionaryStudents = new ConcurrentDictionary<int, Student>();
            dictionaryStudents.TryAdd(101, new Student() { ID = 101, Name = "Anurag", Branch = "CSE" });
            dictionaryStudents.TryAdd(102, new Student() { ID = 102, Name = "Mohanty", Branch = "CSE" });
            dictionaryStudents.TryAdd(103, new Student() { ID = 103, Name = "Sambit", Branch = "ETC" });

            Console.WriteLine("ConcurrentDictionary Elements");
            foreach (KeyValuePair<int, Student> item in dictionaryStudents)
            {
                Console.WriteLine($"Key: {item.Key}, ID: {item.Value.ID}, Name: {item.Value.Name}, Branch: {item.Value.Branch}");
            }


            //To get all the keys of ConcurrentDictionary use the keys properties of ConcurrentDictionary
            Console.WriteLine("\nAll Keys in ConcurrentDictionary");
            foreach (int key in dictionaryStudents.Keys)
            {
                Console.WriteLine(key + " ");
            }

            // Once you get the keys, then get the values using the keys
            Console.WriteLine("\nAll Keys and values in ConcurrentDictionary");
            foreach (int key in dictionaryStudents.Keys)
            {
                var student = dictionaryStudents[key];
                Console.WriteLine($"Key: {key}, ID: {student.ID}, Name: {student.Name}, Branch: {student.Branch}");
            }

            //To get all the values in the ConcurrentDictionary use Values property
            Console.WriteLine("\nAll Student objects in ConcurrentDictionary");
            foreach (Student student in dictionaryStudents.Values)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Branch: {student.Branch}");
            }



            Console.ReadKey();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
    }
}
