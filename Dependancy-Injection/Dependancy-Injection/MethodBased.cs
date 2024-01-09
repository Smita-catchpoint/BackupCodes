using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependancy_Injection

{
    public interface IEngine2
    {
        void Start();

    }
    public class Engine2 : IEngine2
    {
        public void Start()
        {
            Console.WriteLine("DI-MethodBased");
        }
    }

    public class Car2
    {

        public void CarStart(IEngine2 _engine)
        {
            _engine.Start();
            Console.WriteLine("car started..");
        }

    }

    class MethodBased
    {
        static void Main()
        {
            Car2 car2 = new Car2();
            car2.CarStart(new Engine2());
            // IEngine2 engine = new Engine2();
            //car2.CarStart(engine);

        }
    }
}

 //constructorbased DI with autofac framework 

//using Autofac;
//namespace Dependancy_Injection

//{
//    public interface IEngine2
//    { void Area();}
//    public class Engine2 : IEngine2
//    {
//        public void Area()
//        {
//            Console.WriteLine("DI-MethodBased");
//        }
//    }
//    public class Car2
//    {
//         public void CarStart(IEngine2 _engine)
//        {
//            _engine.Area();
//            Console.WriteLine("car started..");
//        }

//    }

//    class MethodBased
//    {
//        static void Main()
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.RegisterType<Engine2>().As<IEngine2>();
//            builder.RegisterType<Car2>();
//            var container = builder.Build();

//            //var car2 = container.Resolve<Car2>();
//            //car2.CarStart(
//            //    container.Resolve<IEngine2>()
//            //    );

//            using (var scope = container.BeginLifetimeScope())
//            {
//                var car2 = container.Resolve<Car2>();
//                car2.CarStart(
//                    container.Resolve<IEngine2>()
//                    );
//            }

//        }
//    }
//}



