using Autofac;
using System;

namespace Dependancy_Injection
{
    public interface IOutput
    {
        void Write(string content);
    }
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
    public interface IDateWriter
    {
        void WriteDate();
    }
    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            _output = output;
        }

        public void WriteDate()
        {
            _output.Write(DateTime.Today.ToShortDateString());
        }
    }

    public class FileName
    {
        //private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            var Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }


            //static void WriteDate()
            //{
            //    // Create the scope, resolve your IDateWriter,use it, then dispose of the scope.
            //    using (var scope = Container.BeginLifetimeScope())
            //    {
            //        var writer = scope.Resolve<IDateWriter>();
            //        writer.WriteDate();
            //    }
            //}


        }
    }
}

