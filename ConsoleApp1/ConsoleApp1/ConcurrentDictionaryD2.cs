using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConcurrentDictionaryD2
    {

        public static void Main()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();

            
            dictionary.TryAdd("USA", "New York, Washington");
            dictionary.TryAdd("NSK", "Nashik");
            dictionary.TryAdd("UK", "United Kingdom");
            dictionary.TryAdd("SA", "Africa");
            dictionary.TryAdd("IND", "India");

            bool IsDupliacteKeyAdded = dictionary.TryAdd("IND", "Mumbai, Bhubaneswar");
            Console.WriteLine("Is Duplicate key Added :" + IsDupliacteKeyAdded);
            Console.WriteLine();

            
            Console.WriteLine("Accessing Elements using For Each Loop");
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Console.WriteLine($"Key:{item.Key}, Value: {item.Value}");
            }
            Console.WriteLine();

            //or
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Key:{item.Key}, Value: {item.Value}");
            }
            Console.WriteLine();

           /* foreach (string key in dictionary.Keys)
            {
                Console.WriteLine($"Key:{key}");
            }
            foreach (string value in dictionary.Values)
            {
                Console.WriteLine($"Key:{value}");
            }*/

            //Accessing Dictionary Elements using For Loop
            for (int i = 0; i < dictionary.Count; i++)
            {
                string key = dictionary.Keys.ElementAt(i);
                string value2 = dictionary.Values.ElementAt(i);
               // string value2 = dictionary[key];
                Console.WriteLine($"Key:{key}, Value: {value2}");

            }
            //Accessing Dictionary Elements using Index Keys
            Console.WriteLine("\nElements using Index Keys");
            Console.WriteLine($"Key: UK, Value: {dictionary["UK"]}");
            Console.WriteLine($"Key: USA, Value: {dictionary["USA"]}");
            Console.WriteLine($"Key: IND, Value: {dictionary["IND"]}");

            //ContainsKey method
            Console.WriteLine("\nIs USA Key Exists : " + dictionary.ContainsKey("USA"));
            Console.WriteLine("\nIs SL Key Exists : " + dictionary.ContainsKey("SL"));


            Console.WriteLine();


            // string removedCountry = string.Empty;
            //to initialize the removedCountry variable with an empty string.
            //to avoid assigning a null value to the variable,which could cause a NullReferenceException if we try to access it later.

            string removedCountry = string.Empty;
            //string removedCountry;
            bool result = dictionary.TryRemove("USA", out removedCountry);
            Console.WriteLine($"Is USA Key Removed: {result}");
            Console.WriteLine($"Removed Value: {removedCountry}");
           

            
             result = dictionary.TryRemove("LS", out removedCountry);
            Console.WriteLine($"\nIs LS Key Removed: {result}");
            Console.WriteLine($"Removed Value: {removedCountry}");
            
            //LS is not present>return false & removedCountry is type of string will store  default vlaue of string is i.e.null

            //dictionary.Clear();
           // Console.WriteLine($"\ncount after removing all the elements: {dictionary.Count}");

            // Try to update the key NSK with new value if the old value = pune
            bool result1 = dictionary.TryUpdate("NSK", "my nashik", "pune");
            Console.WriteLine($"\nIs the key NSK update with TryUpdate Method: {result1}");
            Console.WriteLine($"key NSK, Value: {dictionary["NSK"]}");

           bool result2 = dictionary.TryUpdate("UK", "united ", "United Kingdom");
            Console.WriteLine($"\n Is the UK key is updated : {result1}");
            Console.WriteLine($"key UK ,Value: {dictionary["UK"]}");
            Console.WriteLine();



            Console.WriteLine("BEFORE AddorUpdate method ");
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Console.WriteLine($"Key:{item.Key}, Value: {item.Value}");
            }
            Console.WriteLine();

            //Console.WriteLine("\nIs USA Key Exists : " + dictionary.ContainsKey("USA"));

            //AddorUpdate Method
           dictionary.AddOrUpdate("UK", "Kingdom United", (k, v) => "United Kingdom Updated");
            dictionary.AddOrUpdate("AUS", " Australia", (k, v) => "is a city");

            Console.WriteLine("AFTER AddorUpdate method ");
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Console.WriteLine($" Key:{item.Key}, Value: {item.Value}");
            }




            Console.WriteLine();
            // Get UK or add it with value of United Kingdom.//GetOrAdd
            string Result1 = dictionary.GetOrAdd("UK", "United Kingdom 2");
            Console.WriteLine($"Key:UK, Value: {Result1}");
            Console.WriteLine();

            // Get SL or add it with value Srilanka.
            string Result2 = dictionary.GetOrAdd("SL", "Srilanka");
            Console.WriteLine($"Key:SL, Value: {Result2}");

            Console.WriteLine("\nConcurrentDictionary Elements After GetOrAdd Method");
            foreach (KeyValuePair<string, string> KVP in dictionary)
            {
                Console.WriteLine($"Key:{KVP.Key}, Value: {KVP.Value}");
            }
            Console.WriteLine();

            //TryGetValue method
            if (dictionary.TryGetValue("IND", out string value))
            {
                Console.WriteLine($"\nKey = IND is found in the ConcurrentDictionary, Value: {value}");
            }
            else
            {
                Console.WriteLine($"\nKey = IND is not found in the ConcurrentDictionary");
            }

            Console.ReadKey();
        }



    }
}
