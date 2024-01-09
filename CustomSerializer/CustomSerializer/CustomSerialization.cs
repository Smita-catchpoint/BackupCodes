using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

public class PersonConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var person = (Person)value;

        var jsonObject = new JObject
        {
            { "FirstName", person.FirstName },
            { "LastName", person.LastName },
            { "Age", person.Age },
            { "FullName", person.FullName }
        };

        jsonObject.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);

        var fullName = jsonObject.GetValue("FullName").ToString();
        var names = fullName.Split(' ');

        return new Person
        {
            FirstName = names.Length > 0 ? names[0] : "",
            LastName = names.Length > 1 ? names[1] : "",
            Age = (int)jsonObject.GetValue("Age")
        };
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Person);
    }
}

class CustomSerialization
{
    static void Main()
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30
        };

        var json = JsonConvert.SerializeObject(person, Formatting.Indented, new PersonConverter());
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        var deserializedPerson = JsonConvert.DeserializeObject<Person>(json, new PersonConverter());
        Console.WriteLine("\nDeserialized Person:");
        Console.WriteLine($"First Name: {deserializedPerson.FirstName}");
        Console.WriteLine($"Last Name: {deserializedPerson.LastName}");
        Console.WriteLine($"Age: {deserializedPerson.Age}");
        Console.WriteLine($"Full Name: {deserializedPerson.FullName}");
    }
}