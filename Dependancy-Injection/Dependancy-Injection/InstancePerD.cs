//using Autofac;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dependancy_Injection
//{

//    public interface IMyService3
//    {
//        void Something();
//    }

//    public class MyService3 : IMyService3
//    {
//        public void Something()
//        {
//            Console.WriteLine("InstancePerDependency: Doing something");
//        }
//    }

//    class InstancePerD
//    {
//        static void Main()
//        {
//            var builder = new ContainerBuilder();
//            builder.RegisterType<MyService3>().As<IMyService3>();

//            using (var container = builder.Build())
//            {
//                var myService1 = container.Resolve<IMyService3>();
//                myService1.Something(); 

//                var myService2 = container.Resolve<IMyService3>();
//                myService2.Something(); 
//            }
//        }
//    }

//}

using Autofac;
using System;

public interface IMyService
{
    void DoSomething();
}

public class MyService : IMyService
{
    private static int instanceCount = 0;

    public MyService()
    {
        instanceCount++;
    }

    public void DoSomething()
    {
        Console.WriteLine($"InstancePerDependency: Instance {instanceCount}: Doing something");
    }
}

class InstancePerD
{
    static void Main()
    {

        var builder = new ContainerBuilder();


        builder.RegisterType<MyService>().As<IMyService>();


        using (var container = builder.Build())
        {

            var myService1 = container.Resolve<IMyService>();
            myService1.DoSomething();


            var myService2 = container.Resolve<IMyService>();
            myService2.DoSomething();
        }
    }
}


