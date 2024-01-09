using Autofac;

namespace Dependancy_Injection
{
    public class Flowerr
    {
        public string Type { get; set; }

        public Flowerr(string type)
        {
            Type = type;
        }
        public void PrintType()
        {
            Console.WriteLine($"This is a {Type} Flower.");
        }
    }

    internal class Demo
    
        {
            static void Main(string[] args)
            {
                var builder = new ContainerBuilder();

                // Register different types of cars as services using lambda expressions
                builder.Register(c => new Flowerr("Lilly")).As<Flowerr>();
                builder.Register(c => new Flowerr("Rose")).Named<Flowerr>("Rose");
                builder.Register(c => new Flowerr("Lotus")).Keyed<Flowerr>("Lotus");

                var container = builder.Build();

                using (var scope = container.BeginLifetimeScope())
                {
                    var f1 = scope.Resolve<Flowerr>(); 
                    f1.PrintType(); 

                    var f2 = scope.ResolveNamed<Flowerr>("Rose"); 
                    f2.PrintType();

                    var f3 = scope.ResolveKeyed<Flowerr>("Lotus"); 
                    f3.PrintType();
                }
            }
        }
    }



