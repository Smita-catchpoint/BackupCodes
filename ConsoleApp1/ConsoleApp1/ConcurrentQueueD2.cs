using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConcurrentQueueD2
    {
        
        static void Main(string[] args)
        {
            ConcurrentQueue<int> queue2 = new ConcurrentQueue<int>();
            queue2.Enqueue(10);
            queue2.Enqueue(20);
            queue2.Enqueue(30);
            queue2.Enqueue(40);

            foreach (var item in queue2)
            {
                Console.WriteLine("Items before dequeue:" + item);
            }
            Console.WriteLine( "count of elements: {0}  ",queue2.Count );

            // queue2.Enqueue(null); compile time error

            Console.WriteLine();
            bool r = queue2.TryPeek(out int v);
            Console.WriteLine("Peeked value:" + v);
            Console.WriteLine(r);

            Console.WriteLine( );
            bool result= queue2.TryDequeue(out int value);
            Console.WriteLine("removed value:" +value);
            Console.WriteLine( result);

            Console.WriteLine();
            foreach (var item in queue2)
            {
                Console.WriteLine("Items after dequeue:" + item);
            }

            Console.WriteLine( );
            queue2.Clear();
            result = queue2.TryDequeue(out int value2);
            Console.WriteLine("removed value:" + value2);
            Console.WriteLine(result);


        }
    }
}
