
//using System;
//namespace Dependancy_Injection
//{         //ProperyBased DI-->manually
//    public interface IShapes
//    {
//        void Area();

//    }
//    public class Reactangle : IShapes
//    {
//        public void Area()
//        {
//            Console.WriteLine("Area of reactangle is A = L*W cm^2");
//        }
//    }
//    public class Circle : IShapes
//    {
//        public void Area()
//        {
//            Console.WriteLine("Area of Circle A = π * r^2 ");
//        }
//    }

//    public class Shapes
//    {
//        public IShapes s1 { get; set; }

//        public void PrintArea()
//        {
//            s1.Area();
//        }
//    }
//    class PropertyBasedDI
//    {
//        static void Main(string[] args)
//        {
//            Shapes r = new Shapes();
//            r.s1 = new Reactangle();
//            r.PrintArea();

//            Shapes c = new Shapes();
//            c.s1 = new Reactangle();
//            c.PrintArea();
//        }
//    }


//}using System;
using Autofac; // Add Autofac reference
namespace Dependancy_Injection
{         //ProperyBased DI-->manually
    public interface IShapes
    {
        void Area();

    }
    public class Reactangle : IShapes
    {
        public void Area()
        {
            Console.WriteLine("Area of reactangle is A = L*W cm^2");
        }
    }
    public class Circle : IShapes
    {
        public void Area()
        {
            Console.WriteLine("Area of Circle A = π * r^2 ");
        }
    }

    public class Shapes
    {
        public IShapes s1 { get; set; }

        public void PrintArea()
        {
            s1.Area();
        }
    }
    class PropertyBasedDI
    {
        static void Main(string[] args)
        {
            // Create a ContainerBuilder object
            var builder = new ContainerBuilder();

            // Register the components with Autofac
            builder.RegisterType<Reactangle>().As<IShapes>();
            builder.RegisterType<Circle>().As<IShapes>();
            builder.RegisterType<Shapes>();

            // Build a container from the builder
            var container = builder.Build();

            // Resolve an instance of Shapes from the container
            var r = container.Resolve<Shapes>();

            // Assign an instance of Reactangle to the s1 property using Autofac
            r.s1 = container.Resolve<IShapes>();

            // Call the PrintArea method of r
            r.PrintArea();

            // Resolve another instance of Shapes from the container
            var c = container.Resolve<Shapes>();

            // Assign an instance of Circle to the s1 property using Autofac
            c.s1 = container.Resolve<IShapes>();

            // Call the PrintArea method of c
            c.PrintArea();
        }
    }


}

