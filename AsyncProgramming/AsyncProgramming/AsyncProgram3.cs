using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class AsyncProgram3
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started");

            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = PerformTaskAsync("Task 1", 3000);
            tasks[1] = PerformTaskAsync("Task 2", 2000);
            tasks[2] = PerformTaskAsync("Task 3", 5000);

            Task<int> firstCompleted = await Task.WhenAny(tasks);
            int index = Array.IndexOf(tasks, firstCompleted);
            Console.WriteLine($"Task {index + 1} completed first");

            Console.WriteLine("Main Method End");
        }

        static async Task<int> PerformTaskAsync(string taskName, int delayMilliseconds)
        {
            Console.WriteLine($"{taskName} started");
            await Task.Delay(delayMilliseconds);
            Console.WriteLine($"{taskName} completed");
            return delayMilliseconds;
        }
    }


}
