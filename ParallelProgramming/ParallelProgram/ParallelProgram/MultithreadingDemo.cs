using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingDemo
{
    class MultithreadingDemo
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread((Method1) => { Console.WriteLine("Hello"); });
            t1.Start();
            Thread t2 = new Thread((Method2) => {  Console.WriteLine("World"); });
            t2.Start();
        }

        

    }
}
