using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CustomSerializer
{
    public class KeysJsonConverter : JsonConverter
    {
        private readonly Type[] _types;

        public KeysJsonConverter(params Type[] types)
        {
            _types = types;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

                o.WriteTo(writer);
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
 
            JObject jsonObject = JObject.Load(reader);

        
            JArray keysArray = (JArray)jsonObject["Keys"];
            IList<string> propertyNames = keysArray.ToObject<List<string>>();

            object targetObject = Activator.CreateInstance(objectType);

        
            foreach (var propertyName in propertyNames)
            {
                JToken propertyValue = jsonObject[propertyName];
                PropertyInfo property = objectType.GetProperty(propertyName);

                if (property != null)
                {
                
                    object convertedValue = propertyValue.ToObject(property.PropertyType, serializer);

                    property.SetValue(targetObject, convertedValue);
                }
            }

            return targetObject;
        }

        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }

    public class Employee5
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Roles { get; set; }
    }

    class CustomSerialization3
    {
        static void Main()
        {
            Employee5 employee = new Employee5
            {
                FirstName = "James",
                LastName = "Newton-King",
                Roles = new List<string>
            {
                "Admin"
            }
            };

            string json = JsonConvert.SerializeObject(employee, Formatting.Indented, new KeysJsonConverter(typeof(Employee5)));

            Console.WriteLine(json);

            Console.WriteLine();

            Employee5 newEmployee5 = JsonConvert.DeserializeObject<Employee5>(json, new KeysJsonConverter(typeof(Employee5)));

            Console.WriteLine($"FirstName: {newEmployee5.FirstName}");
        }
    }
}
 