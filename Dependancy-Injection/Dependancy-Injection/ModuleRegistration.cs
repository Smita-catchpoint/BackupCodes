using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependancy_Injection
{


    public interface IMyService5
    {
        void Do();
    }

    public class MyService5 : IMyService5
    {
        public void Do()
        {
            Console.WriteLine("MyService is doing something.");
        }
    }

    public interface IAnotherService
    {
        void Do2();
    }

    public class AnotherService : IAnotherService
    {
        public void Do2()
        {
            Console.WriteLine("AnotherService is doing something else.");
        }
    }

    public class MyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<MyService5>().As<IMyService5>();
            builder.RegisterType<AnotherService>().As<IAnotherService>();
        }
    }

    class ModuleRegistration
    {
        static void Main()
        {

            var builder = new ContainerBuilder();

            builder.RegisterModule(new MyModule());


            using (var container = builder.Build())
            {

                var myService = container.Resolve<IMyService5>();
                var anotherService = container.Resolve<IAnotherService>();

                myService.Do();
                anotherService.Do2();
            }
        }
    }

}
