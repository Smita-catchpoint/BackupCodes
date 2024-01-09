using Autofac;
namespace Dependancy_Injection
{
    public interface IMyService1
    {
        void DoSomethingg();
    }
    public class MyService1 : IMyService1
    {
        public void DoSomethingg()
        {
            Console.WriteLine("MethodDependancy-->Autofac");
        }
    }

    public class MethodDependancy
    {
        private  IMyService1 _myService1;

        public void SetMyService(IMyService1 myService1)
        {
            _myService1 = myService1;
        }
        public void Execute1()
        {
            _myService1.DoSomethingg();
        }

    }
    internal class Demo3
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MyService1>().As<IMyService1>();
           // builder.RegisterType(typeof(MethodDependancy));
            builder.RegisterType<MethodDependancy>().AsSelf();

            var container = builder.Build();
            var data = container.Resolve<MethodDependancy>();
            data.SetMyService(container.Resolve<IMyService1>());
            data.Execute1();


        }
    }
}
