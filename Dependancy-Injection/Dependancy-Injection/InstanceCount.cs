using Autofac;

namespace Dependancy_Injection
{

    public interface IMyService4
    {
        void DoSomething();
    }

    public class MyService4 : IMyService4
    {
        private static int instanceCount = 0;

        public MyService4()
        {
            instanceCount++;
        }

        public void DoSomething()
        {
            Console.WriteLine($"Instance {instanceCount}: Doing something");
        }
    }

    class InstanceCount
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MyService4>()
                   .As<IMyService4>()
                   .OnActivating(e => Console.WriteLine($"Activating instance of {e.Instance.GetType().Name}"));

            using (var container = builder.Build())
            {
                var myService1 = container.Resolve<IMyService4>();
                myService1.DoSomething();

                var myService2 = container.Resolve<IMyService4>();
                myService2.DoSomething();
            }
        }
    }



}
