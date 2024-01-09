using Autofac;
namespace Dependancy_Injection
{
    public interface IMyService
    {
        void DoSomething();
    }
    public class MyService : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("ConstructorDependancy-->autofac");
        }
    }

    public class ConstructorDependancy
    {
      private readonly IMyService _myService;

        public ConstructorDependancy(IMyService myService)
        {
            _myService = myService;
        }
        public void Execute()
        {
            _myService.DoSomething();
        }

    }
    internal class Demo2
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MyService>().As<IMyService>();
            builder.RegisterType(typeof(ConstructorDependancy));
            //builder.RegisterType<ConstructorDependancy>().AsSelf();

            var container = builder.Build();
            var data = container.Resolve<ConstructorDependancy>();
            data.Execute();


        }
    }
}
