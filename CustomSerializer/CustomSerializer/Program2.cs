using Newtonsoft.Json;
using System;

namespace CustomSerializer
{
         class Program2
        {
            static void Main(string[] args)
        {     // 1.Serialization of object
                Console.WriteLine("Serialization");
                Movie movie = new Movie { Id = 1, Title = "Mission Impossible" };
              //movie is a object> convert this to a string
                string result = JsonConvert.SerializeObject(movie);
                Console.WriteLine(result);

              // 2.Deserialization of object
                Console.WriteLine("\nDeserialization");
              //string is converted to object            
            Movie newMovie = JsonConvert.DeserializeObject< Movie >(result); 
                Console.WriteLine("Id : " + newMovie.Id);
                Console.WriteLine("Title : " + newMovie.Title);

              // 3.Serialization of collection
              Console.WriteLine("\nSerialization of collection");
                List<Movie> movies = new List <Movie>{
                new Movie { Id = 1, Title = "Titanic" },
                new Movie { Id = 2, Title = "The martian" },
                new Movie { Id = 3, Title = "Black panther" } ,
                new Movie { Id = 4, Title = "Deadpool 2" } ,
              };

                string collectionResult = JsonConvert.SerializeObject(movies);
                Console.WriteLine(collectionResult);

              // 4.Deserialization of collection
               Console.WriteLine("\nDeserialization of collection");
               List< Movie>  newMovies = JsonConvert.DeserializeObject < List< Movie >>(collectionResult);
              //foreach (var item in newMovies)
              //{
              //    Console.WriteLine("Id : " + item.Id + "\tTitle : " + item.Title);
              //}
               foreach (var item in newMovies)
               {
                Console.WriteLine($"Id:{item.Id}, Title:{item.Title}");
                
               }
         }


            class Movie
            {
                public int Id { get; set; }
                public string Title { get; set; }
            }

         }
    }


