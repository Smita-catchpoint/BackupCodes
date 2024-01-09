using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{           //collection class>not type safe & thread safe , generic collections >not thread safe
            //Concurrent Collection > Type safe & Thread safe 
    class DictionaryDemo

    {
        static Dictionary<int , string> dictionary = new Dictionary<int , string>();
        static readonly object lockobject = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            foreach(var item in dictionary) 
            {
                Console.WriteLine($"key:{item.Key },value:{item.Value}" );
            }

            Console.ReadKey();
        } 

        public static void Method1() {
            for (int i = 0; i < 10; i++)
            {
               lock (lockobject){
           
                    if (!dictionary.ContainsKey(i))
                    {
                        dictionary.Add(i, "Added by method1 " + i);
                        Thread.Sleep(100);
                    }

                }
            }

        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                lock(lockobject) {
                    if (!dictionary.ContainsKey(i))
                    {
                        dictionary.Add(i, "Added by method2 " + i);
                        Thread.Sleep(100);
                    }
                }
                
            }
        }
    }
}

//The lock statement ensures that only one thread can access the dictionary at a time, preventing any race conditions or data corruption.
