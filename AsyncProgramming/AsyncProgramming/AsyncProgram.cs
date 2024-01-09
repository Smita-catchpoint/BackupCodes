//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AsyncProgramming
//{
//    internal class AsyncProgram
//    {
//        static async Task<int> Task1(string taskName, int delayMs)
//        {
//            Console.WriteLine($"{taskName} started");
//            await Task.Delay(delayMs);
//            Console.WriteLine($"{taskName} completed");
//            return delayMs;
//        }
//        static async Task Main(string[] args)
//        {
//            Console.WriteLine("Main Method Started");

//            Task<int> task1 = Task1("Task 1", 3000);
//            Task<int> task2 = Task1("Task 2", 2000);
//            Task<int> task3 = Task1("Task 3", 5000);

//            int result1 = await task1;
//            int result2 = await task2;
//            int result3 = await task3;

//            Console.WriteLine($"Results: {result1}, {result2}, {result3}");

//            Console.WriteLine("Main Method End");
//        }


//    }

//}
