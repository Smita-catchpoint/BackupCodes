using Autofac;
namespace Dependancy_Injection
{  // DI with autofac framework -->methodbased
    public interface IEng
    { 
        void Start();
    }
    public class Eng : IEng
    {
        public void Start()
        {
            Console.WriteLine("DI-MethodBased");
        }
    }
    public class Bike
    {
        public void BikeStart(IEng _eng)
        {
            _eng.Start();
            Console.WriteLine("car started..");
        }

    }

    class ContainerConfiguration2
    {
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Eng>().As<IEng>();
            builder.RegisterType<Bike>();
            var container = builder.Build();


            using (var scope = container.BeginLifetimeScope())
            {
                var bike = container.Resolve<Bike>();
                bike.BikeStart(
                    container.Resolve<IEng>()
                    );

            }

        }
    }
}