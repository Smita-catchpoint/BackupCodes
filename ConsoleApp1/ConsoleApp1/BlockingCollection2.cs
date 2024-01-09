using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp1
{
     class BlockingCollection2
    {
        //shared collection
        public static BlockingCollection<int> bc = new BlockingCollection<int>();
        static void Main()
        {
            //ProduceItem();
            //ConsumeItem();
            Thread t1 = new Thread(ProduceItem);
            t1.Start();
            Thread t2 = new Thread(ConsumeItem);
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadKey();
        }
        static void ProduceItem()
        {
            for (int i = 1; i < 10; ++i)
            {
                Console.WriteLine($"Producer Thread Produce: {i}");
                bc.Add(i);
               
            }
                bc.CompleteAdding();
            Console.WriteLine( );
        }
        
        static void ConsumeItem()
        {    
            while (!bc.IsCompleted)
            {
                //bc.TryTake(out int item);
                //Console.WriteLine($"consumer thread consume: {item}");
                Console.WriteLine($"consumer Thread Consume: "+ bc.Take());
            }

        }
    }
}
