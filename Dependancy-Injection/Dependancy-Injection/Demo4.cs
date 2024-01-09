using Autofac;
namespace Dependancy_Injection
{
    public interface IService
    {
        void Work();
    }
    public class Service : IService
    {
        public void Work()
        {
            Console.WriteLine("Parameter Dependancy-->Autofac");
        }
    }

    public class ParameterDependancy
    {
        private readonly IService _service;

        public ParameterDependancy(IService service)
        {
            _service = service;
        }
        public void Execute1()
        {
            _service.Work();
        }

    }
    internal class Demo4
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>();
           // builder.RegisterType(typeof(ParameterDependancy));
            //builder.RegisterType<ParameterDependancy>().As<ParameterDependancy>();
            builder.RegisterType<ParameterDependancy>().AsSelf();

            var container = builder.Build();
            var data = container.Resolve<ParameterDependancy>(
                new TypedParameter(typeof(IService),container.Resolve<IService>()));
               data.Execute1();
         


        }
    }
}
