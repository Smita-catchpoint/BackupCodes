using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   //thread safe >unorder >duplicate allowed>similar to list<T>
    class ConcurrentBag1
    {
        static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();//consutructor1
            //Add
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);


            foreach(var item in bag)
            {
                Console.WriteLine("added item: "+ item);
            }
            Console.WriteLine( );


            //CopyTo(T[] array, int index):Copy elements of bag to array
            //int[] array = new int[6];
            Console.WriteLine("\nCopyTo >elements of array:");
            int[] array = new int[bag.Count];
            bag.CopyTo(array, 0);
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }

            // ToArray(): Copy elements of bag to new array.
            int[] elements = bag.ToArray();
            Console.WriteLine("\nToArray >elements of array:");
            foreach (var element in elements) { 
                Console.WriteLine(element);
            }



            string[] fruits = { "Apple", "Mango", "Orange" };
            ConcurrentBag<string> bag1 = new ConcurrentBag<string>(fruits);//constructor 2
            Console.WriteLine("\nelements of bag1: ");

            foreach(var item in bag1) { 
                Console.WriteLine(item);
            }

            //TryTake >remove and return obj
            Console.WriteLine("\nTryTake > IsRemoved");
            bool result = bag1.TryTake(out string value);
            Console.WriteLine(result);
            Console.WriteLine(value);

            //TryTake >peek 
            Console.WriteLine("\nTryPeek > IsPeeked");
            bool result2 = bag1.TryPeek(out string v);
            Console.WriteLine(result2);
            Console.WriteLine(v);

            Console.WriteLine("\nCount: "+ bag1.Count);}     
    }
}
