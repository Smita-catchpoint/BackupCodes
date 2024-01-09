using Autofac;

namespace Dependancy_Injection
{
    public interface ILogger
    {
        void Log(string message);
    } 
    public class Logger : ILogger
    {
        public void Log(string message) {
            Console.WriteLine($"Logging:{message}");
        }
    }

    public interface IDataService
    {
        void GetData();
    }
    public class DataService : IDataService
    {
        public void GetData()
        {
            Console.WriteLine("getting data...");
        }
    }

    internal class LoggingModule : Module
    {        //registering services into autofac madule
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<DataService>().As<IDataService>();
        }

    }

    public class ModuleRegistration2
    {
        static void Main(string[] args)
        {
            var builder= new ContainerBuilder();
            builder.RegisterModule(new LoggingModule()); //register module
            var container = builder.Build();

            //resolve & use services 
            using(var scope = container.BeginLifetimeScope())
            {
                var logger = scope.Resolve<ILogger>();
                logger.Log("hello ");

                var dataservice = scope.Resolve<IDataService>();
                dataservice.GetData();
            }

        }
    }
}

