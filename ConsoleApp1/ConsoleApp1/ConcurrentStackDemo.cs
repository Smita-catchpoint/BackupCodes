using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
namespace ConsoleApp2
{
    internal class ThreadTest
    {
        static void Main(string[] args)
        {

            ConcurrentStack<int> numbers = new ConcurrentStack<int>();

            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);
            numbers.Push(40);
            numbers.Push(50);
            numbers.Push(60);


            // Pop 
            int result;
            Console.WriteLine(numbers.Count);

            if (numbers.TryPop(out result))
            {
                Console.WriteLine("Topmost: " + result);
            }

            if (numbers.TryPeek(out result))
            {
                Console.WriteLine("new top: " + result);
            }

            Console.WriteLine("isempty or not: " + numbers.IsEmpty);
            Console.WriteLine("count: " + numbers.Count);



            Console.WriteLine("copying Concurrent stack elements to array");
            int[] array = new int[6];

            numbers.CopyTo(array, 0);

            Console.WriteLine(string.Join(", ", array));



            ConcurrentStack<string> stack = new ConcurrentStack<string>();

            stack.Push("Hello");
            stack.Push("World");

            // Get an enumerator for the stack
            var enumerator = stack.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            //TryPop 
            Console.WriteLine();
            bool result3 = stack.TryPop(out string value);
            Console.WriteLine("popped value:" + value);
            Console.WriteLine(result3);

            //TryPushRange
            ConcurrentStack<int> number = new ConcurrentStack<int>();
            int[] items = new int[] { 10, 20, 30 };

            number.PushRange(items);
            Console.WriteLine(string.Join(" ", items));

            //TryPeek
            int top;
            if (number.TryPeek(out top))
            {
                Console.WriteLine(top);
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }

            //ToArray
            ConcurrentStack<int> num = new ConcurrentStack<int>();

            num.Push(10);
            num.Push(20);
            num.Push(30);

            int[] array2 = num.ToArray();
            Console.WriteLine(string.Join(", ", array2));

            //TryPopRange
            ConcurrentStack<int> num2 = new ConcurrentStack<int>();

            num2.PushRange(new int[] { 10, 20, 30 });

            int[] element = new int[3];

            int count = num2.TryPopRange(element);
            // Print the number of items popped and the array contents 
            Console.WriteLine("Popped {0} items", count);
            Console.WriteLine(string.Join(", ", element));

            //OR

            ConcurrentStack<int> s = new ConcurrentStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            int[] i = new int[3];

            // Pop three items from the stack atomically
            //public int TryPopRange (T[] items, int startIndex, int count);
            int popped = s.TryPopRange(i, 0, 3);
            Console.WriteLine("Popped {0} items: ", popped);
            foreach (int n in i)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            // OR

            int[] elementsToRemove = new int[2];
            int countElementsToRemove = s.TryPopRange(elementsToRemove);
            Console.WriteLine("\ncountElementsToRemove:" + countElementsToRemove);
            Console.WriteLine("\n Removed elements:");
            foreach (int n in elementsToRemove)
            {
                Console.WriteLine(n);
            }







        }


    }
}