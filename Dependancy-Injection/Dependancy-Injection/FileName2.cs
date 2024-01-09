using Autofac;
using System;

namespace Dependancy_Injection
{
    interface Flower
    {
        void Colour();
    }

    public class rose : Flower
    {
        public void Colour()
        {
            Console.WriteLine("colour of rose is red");
        }
    }

    public class lilly : Flower
    {
        public void Colour()
        {
            Console.WriteLine("colour of lilly is white");
        }
    }

    internal class FileName2
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<rose>().As<Flower>();
            builder.RegisterType<lilly>().Named<Flower>("lilly");
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var rose = scope.Resolve<Flower>();
                rose.Colour();

                var lilly = scope.ResolveNamed<Flower>("lilly");
                lilly.Colour();
            }
        }
    }
}





//using Autofac;
//using System;

//namespace Dependancy_Injection
//{
//    // An interface that represents a car
//    public interface IFlower
//    {
//        void PrintColour();
//    }

//    public class Lilly : IFlower
//    {
//        public void PrintColour()
//        {
//            Console.WriteLine("This is a white lilly.");
//        }
//    }


//    public class Rose : IFlower
//    {
//        public void PrintColour()
//        {
//            Console.WriteLine("This is an red rose.");
//        }
//    }


//    public class Lotus : IFlower
//    {
//        public void PrintColour()
//        {
//            Console.WriteLine("This is a pink lotus.");
//        }
//    }

//    internal class FileName2
//    {
//        static void Main(string[] args)
//        {
//            ContainerBuilder builder = new ContainerBuilder();

//            // Register types of Flower as services using lambda expressions
//            builder.RegisterType<Lilly>().As<IFlower>();
//            builder.RegisterType<Rose>().Named<IFlower>("Rose");
//            builder.RegisterType<Lotus>().Keyed<IFlower>("Lotus");

//            var container = builder.Build();

//            using (var scope = container.BeginLifetimeScope())
//            {
//                var rose = scope.Resolve<IFlower>();
//                rose.PrintColour();

//                var lilly = scope.ResolveNamed<IFlower>("Rose");
//                lilly.PrintColour();

//                var lotus = scope.ResolveKeyed<IFlower>("Lotus");
//                lotus.PrintColour();
//            }
//        }
//    }
//}
