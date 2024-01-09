using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConcurrentStackDemo2
    {
        public static void Main(string[] args)
        {
            ConcurrentStack<Student> stack = new ConcurrentStack<Student>();
            stack.Push(new Student() { ID = 1, Name = "JONH", Branch = "E&tc" });
            stack.Push(new Student() { ID = 2, Name = "MAYA", Branch = "CSE" });
            stack.Push(new Student() { ID = 3, Name = "ROHAN", Branch = "Civil" });

            foreach (var student in stack)
            {
                Console.WriteLine($"ID: {student.Name} ,NAME: {student.Name},Branch: {student.Branch}S");
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
