using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class Person5
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class MyTestClass
{
    public Person5 Person { get; set; }
    public IList<int> List { get; set; }
    public string StrData { get; set; }
    public int IntData { get; set; }
    public float FloatData { get; set; }
    public bool BooleanData { get; set; }
}

public class MyTestClassConverter : JsonConverter<MyTestClass>
{
    public override MyTestClass ReadJson(JsonReader reader, Type objectType, MyTestClass existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);

        var myTestClass = new MyTestClass
        {
            Person = DeserializePerson(jsonObject["cp-key1"]?.ToString()),
            List = DeserializeList(jsonObject["cp-key2"]?.ToString()),
            StrData = jsonObject["cp-key3"]?.ToString(),
            IntData = jsonObject["cp-key4"]?.ToObject<int>() ?? default,
            FloatData = jsonObject["cp-key5"]?.ToObject<float>() ?? default,
            BooleanData = jsonObject["cp-key6"]?.ToObject<bool>() ?? default
        };

        return myTestClass;
    }

    public override void WriteJson(JsonWriter writer, MyTestClass value, JsonSerializer serializer)
    {
        var jsonObject = new JObject
        {
            ["cp-key1"] = SerializePerson(value.Person),
            ["cp-key2"] = SerializeList(value.List),
            ["cp-key3"] = value.StrData,
            ["cp-key4"] = value.IntData,
            ["cp-key5"] = value.FloatData,
            ["cp-key6"] = value.BooleanData
        };

        jsonObject.WriteTo(writer);
    }

    private Person5 DeserializePerson(string personString)
    {
        if (string.IsNullOrEmpty(personString)) return null;

        var personData = personString.Split(',');
        if (personData.Length == 3)
        {
            return new Person5
            {
                Name = personData[0],
                Age = int.Parse(personData[1]),
                City = personData[2]
            };
        }

        return null;
    }

    private string SerializePerson(Person5 person)
    {
        return person != null ? $"{person.Name},{person.Age},{person.City}" : null;
    }

    private IList<int> DeserializeList(string listString)
    {
        if (string.IsNullOrEmpty(listString)) return null;

        return Array.ConvertAll(listString.Split(','), int.Parse);
    }

    private string SerializeList(IList<int> list)
    {
        return list != null ? string.Join(",", list) : null;
    }
}

class CustomSerialization5
{
    static void Main()
    {
        var json = @"{
            ""cp-key1"":""smita,20,Bangalore"",
            ""cp-key2"":""10,20,30,40,50"",
            ""cp-key3"":""I am String"",
            ""cp-key4"":10,
            ""cp-key5"":20.20,
            ""cp-key6"":true
        }";

        var settings = new JsonSerializerSettings
        {
            Converters = { new MyTestClassConverter() },
            Formatting = Formatting.Indented
        };

        var myTestClass = JsonConvert.DeserializeObject<MyTestClass>(json, settings);
        Console.WriteLine(JsonConvert.SerializeObject(myTestClass, Formatting.Indented));
    }
}