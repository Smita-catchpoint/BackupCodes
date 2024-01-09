using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConcurrentQueueDemo
    {
        public static void Main(string[] args) {
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");
            queue.Enqueue("Cherry");

            //Adding Dublicates
            queue.Enqueue("Cherry");

           // queue.Enqueue(""); empty string does not throw an error

            Console.WriteLine("The queue contains:");
            foreach (string item in queue) { Console.WriteLine(item); }


            //copyTo
            string[] array = new string[7]; 
            queue.CopyTo(array, 0);

            Console.WriteLine("The array contains:");
            foreach (string item in array) {
                Console.WriteLine(item);
            }

            //ToArray
            string[] newArray = queue.ToArray();
            Console.WriteLine("The new array contains:");
            foreach (string item in newArray) { 
                Console.WriteLine(item);
            }

            string first;
            if (queue.TryPeek(out first)) {
                Console.WriteLine("The first item is { 0 }", first);
            } 
            else { Console.WriteLine("The queue is empty"); }

            string second;
            if (queue.TryDequeue(out second)) {
                Console.WriteLine("The second item is { 0 }", second); 
            }
            else { Console.WriteLine("The queue is empty"); }


            queue.Clear();


            Console.WriteLine("The queue has { 0} items", queue.Count);

         


                





        }
    }
}