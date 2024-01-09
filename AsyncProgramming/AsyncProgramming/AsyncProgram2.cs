//using System;

//namespace AsyncProgramming
//{
//    internal class AsyncProgram2
//    {
//        static async Task Main(string[] args)
//        {
//            Console.WriteLine("Main Method Started");

//            static async Task Task1(string taskName, int delayms)
//            {
//                Console.WriteLine($"{taskName} started");
//                await Task.Delay(delayms);
//                Console.WriteLine($"{taskName} completed");
//            }

//            Task[] tasks = new Task[3];
//            tasks[0] = Task1("Task 1", 3000);
//            tasks[1] = Task1("Task 2", 2000);
//            tasks[2] = Task1("Task 3", 5000);

//            await Task.WhenAll(tasks);


//            Console.WriteLine("All tasks completed");

//            Console.WriteLine("Main Method End");
//        }

//    }
//}
