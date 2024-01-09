using System;
using System.Collections.Concurrent;


namespace ConsoleApp1
{           //Concurrent Collection > Type safe & Thread safe we did not need to add explicit locks.
    class ConcurrentDictionaryDemo

    {
        static ConcurrentDictionary<int, string> dictionary = new ConcurrentDictionary<int, string>();
        static readonly object lockobject = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"key:{item.Key},value:{item.Value}");
            }


            /* foreach (var item in dictionary)
             {
                 Console.WriteLine($"key:{item.Key},value:{item.Value}");
             }*/

            Console.WriteLine("Capacity:count of elem: "+ dictionary.Count);


            // Console.WriteLine("element at second pos " + dictionary[1]);


            Console.ReadKey();
        }

        public static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.TryAdd(i, "Added by method1 " + i);
                Thread.Sleep(100);
               
            }

        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.TryAdd(i, "Added by method2 " + i);
                Thread.Sleep(100);

            }
          
        }
    }
}
