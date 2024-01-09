using System;
using System.Collections.Concurrent;
namespace ConsoleApp1
{
    class FileName
    {
        static void Main()
        {
            BlockingCollection<int> blockingCollection = new BlockingCollection<int>();

            //Thread 1 (Producer Thread) Adding Item to blockingCollection
            Task producerThread = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                   // Console.WriteLine($"Added item: {i}");
                    blockingCollection.Add(i);
                }

                //Mark Collection will not accept any more additions
                blockingCollection.CompleteAdding();
            });

            //Thread 2 (Consumer Thread) Removing Item from blockingCollection and Printing on the Console
            Task consumerThread = Task.Factory.StartNew(() =>
            {
                //Loop will continue as long as IsCompleted returns false
                while (!blockingCollection.IsCompleted)
                {
                 
                    int item = blockingCollection.Take();
                    Console.WriteLine($"Removed item: {item}");
                    //Console.Write($"{item} ");
                }
            });

            Task.WaitAll(producerThread, consumerThread);
            Console.ReadKey();
        }
    }
}
