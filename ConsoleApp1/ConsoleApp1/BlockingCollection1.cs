using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BlockingCollection1
    {
        static void Main()
        {
            // Capacity 4
            BlockingCollection<int> bC = new BlockingCollection<int>(4);
            //Add Method
            bC.Add(10);
            bC.Add(20);
            //TryAdd Method
            bC.TryAdd(40);
            bC.TryAdd(50);

            //TryAdd Method with TimeSpan
            if (bC.TryAdd(30, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Item 30 Added");
            }
            else
            {
                Console.WriteLine("Item 30 Not added");
            }
            
            Console.WriteLine("\nAll elements before removing");
            foreach (var item in bC)
            {
                Console.WriteLine(item);
            }
            //Take()
            int Result1 = bC.Take();
            Console.WriteLine($"\nTake Method: {Result1}");
            
            //TryTake method with TimeSpan
            if (bC.TryTake(out int Result2, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine($"\nItem Removed  {Result2}");
            }
            else
            {
                Console.WriteLine("\nNo Item Removed");
            }
            
            if (bC.TryTake(out int Result3, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine($"\nItem Removed {Result3}");
            }
            else
            {
                Console.WriteLine("\nNo Item Removed");
            }

            

            Console.ReadKey();

        }

    }
}
