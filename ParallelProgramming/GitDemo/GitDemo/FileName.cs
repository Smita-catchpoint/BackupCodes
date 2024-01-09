using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDemo
{
    internal class FileName
    {
        static void Main()
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();
            // Regular LINQ Query
            Stopwatch regularQueryTimer = Stopwatch.StartNew();
            var squares = numbers.Select(num => num * num).ToArray();
            regularQueryTimer.Stop();
            Console.WriteLine($"Regular LINQ took: {regularQueryTimer.ElapsedMilliseconds} ms");

            // Parallel LINQ Query
            Stopwatch parallelQueryTimer = Stopwatch.StartNew();
            var squaresParallel = numbers.AsParallel().Select(num => num * num).ToArray();
            parallelQueryTimer.Stop();
            Console.WriteLine($"Parallel LINQ took: {parallelQueryTimer.ElapsedMilliseconds} ms");
        }
    }
}
