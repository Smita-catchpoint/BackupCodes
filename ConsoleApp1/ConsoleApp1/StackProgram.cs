using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class StackProgram
    {
        static ConcurrentStack<int> stack = new ConcurrentStack<int>();

        static void Main(string[] args)

        {
            Console.WriteLine( "Main thread started");
            Task t1 = Task.Run(() => PushData(1));
            Task t3 = Task.Run(() => PushData(2));
            Task t2 = Task.Run(() => PopData());
          //  Console.WriteLine("Main thread ended");

            Task.WaitAll(t1,t2);
           


            foreach (var i in stack)
            {
                Console.WriteLine($"items: {i}");

            }
            static void PushData(int value){
                stack.Push(value);
                Console.WriteLine($"Pushed value: {value}");

            }
            static void PopData()
            {
                /*if(stack.TryPop(out int value))
                {
                    Console.WriteLine($"popped value: {value}");
                }else
                {
                    Console.WriteLine("stack is empty");
                        }*/

                Console.WriteLine();
                bool result3 = stack.TryPop(out int value);
                Console.WriteLine("popped value:" + value);
                Console.WriteLine("itemIsPopped:"+ result3);
            }
        }
    }
}
