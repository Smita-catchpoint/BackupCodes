//using Autofac;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dependancy_Injection
//{

//    public interface IMySingletonService
//    {
//        void DoSomething();
//    }

//    public class MySingletonService : IMySingletonService
//    {
//        public void DoSomething()
//        {
//            Console.WriteLine("SingleInstance: Doing something");
//        }
//    }

//    class Singletone
//    {
//        static void Main()
//        {
//            var builder = new ContainerBuilder();
//            builder.RegisterType<MySingletonService>().As<IMySingletonService>().SingleInstance();

//            using (var container = builder.Build())
//            {
//                var myService1 = container.Resolve<IMySingletonService>();
//                myService1.DoSomething();

//                var myService2 = container.Resolve<IMySingletonService>();
//                myService2.DoSomething();
//            }
//        }
//    }

//}

using Autofac;
using System;

public interface IMySingletonService
{
    void DoSomething();
}

public class MySingletonService : IMySingletonService
{
    private static int instanceCount = 0;

    public MySingletonService()
    {
        instanceCount++;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Singleton Instance {instanceCount}: Doing something");
    }
}

class Singletone
{
    static void Main()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<MySingletonService>()
               .As<IMySingletonService>()
               .SingleInstance()
               .OnActivated(e => Console.WriteLine($"Activated Singleton instance of {e.Instance.GetType().Name}"));

        using (var container = builder.Build())
        {

            var singletonService1 = container.Resolve<IMySingletonService>();
            singletonService1.DoSomething();

            // Create another instance (should be the same instance)
            var singletonService2 = container.Resolve<IMySingletonService>();
            singletonService2.DoSomething();
        }
    }
}
