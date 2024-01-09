//using Autofac;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dependancy_Injection
//{

//    public interface IMyScopedService
//    {
//        void DoSomething();
//    }

//    public class MyScopedService : IMyScopedService
//    {
//        public void DoSomething()
//        {
//            Console.WriteLine("InstancePerLifetimeScope: Doing something");
//        }
//    }

//    class InstancePerLifetimeScope
//    {
//        static void Main()
//        {
//            var builder = new ContainerBuilder();
//            builder.RegisterType<MyScopedService>().As<IMyScopedService>().InstancePerLifetimeScope();

//            using (var container = builder.Build())
//            {
//                using (var scope = container.BeginLifetimeScope())
//                {
//                    var myService1 = scope.Resolve<IMyScopedService>();
//                    myService1.DoSomething(); 

//                    var myService2 = scope.Resolve<IMyScopedService>();
//                    myService2.DoSomething();
//                }
//            }
//        }
//    }

//}



//using Autofac;
//using System;

//public interface IMyScopedService
//{
//    void DoSomething();
//}

//public class MyScopedService : IMyScopedService
//{
//    private static int instanceCount = 0;

//    public MyScopedService()
//    {
//        instanceCount++;
//    }

//    public void DoSomething()
//    {
//        Console.WriteLine($"Scoped Instance {instanceCount}: Doing something");
//    }
//}

//class InstancePerLifetimeScope
//{
//    static void Main()
//    {
//        var builder = new ContainerBuilder();

//        builder.RegisterType<MyScopedService>()
//               .As<IMyScopedService>()
//               .InstancePerLifetimeScope()
//               .OnActivated(e => Console.WriteLine($"Activated Scoped instance of {e.Instance.GetType().Name}"));

//        using (var container = builder.Build())
//        {

//            using (var scope = container.BeginLifetimeScope())
//            {
//                var scopedService1 = scope.Resolve<IMyScopedService>();
//                scopedService1.DoSomething();

//                var scopedService2 = scope.Resolve<IMyScopedService>();
//                scopedService2.DoSomething();
//            }
//        }
//    }
//}


using Autofac;
using System;

public interface IMyScopedService
{
    void DoSomething();
}

public class MyScopedService : IMyScopedService
{
    private static int instanceCount = 0;

    public MyScopedService()
    {
        instanceCount++;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Scoped Instance {instanceCount}: Doing something");
    }
}

class InstancePerLifetimeScope
{
    static void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<MyScopedService>()
               .As<IMyScopedService>()
               .InstancePerLifetimeScope()
               .OnActivated(e => Console.WriteLine($"Activated Scoped instance of {e.Instance.GetType().Name}"));

        using (var container = builder.Build())
        {
            using (var scope1 = container.BeginLifetimeScope())
            {
               
                var scopedService1 = scope1.Resolve<IMyScopedService>();
                scopedService1.DoSomething();

                var scopedService2 = scope1.Resolve<IMyScopedService>();
                scopedService2.DoSomething();
            }

      
            using (var scope2 = container.BeginLifetimeScope())
            {
           
                var scopedService3 = scope2.Resolve<IMyScopedService>();
                scopedService3.DoSomething();
            }
        }
    }
}
