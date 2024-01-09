using Autofac;
using System;

namespace Dependancy_Injection
{
    public interface IData
    {
        void Edit();
    }

    public class TextData : IData
    {
        public void Edit()
        {
            Console.WriteLine("Edit text data");
        }
    }

    public class AudioData : IData
    {
        public void Edit()
        {
            Console.WriteLine("Edit Audio data");
        }
    }

    public class Data
    {
        public IData s1 { get; set; }
        //public IData s2 { get; set; }

        public void PrintData()
        {
            //if (s1 != null)
            //{
            Console.WriteLine("Data:");
            s1.Edit();

            //}
            //else
            //{
            //    Console.WriteLine("no data available");
            //}
        }
    }

    internal class FileName3

    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TextData>().As<IData>();
            builder.RegisterType<AudioData>().Named<IData>("AudioData");
            //builder.RegisterType<AudioData>().AsSelf().As<IData>();

            builder.RegisterType<Data>().AsSelf();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var data = scope.Resolve<Data>();
                data.s1 = scope.Resolve<IData>();
                data.PrintData();

                var audioData = scope.ResolveNamed<IData>("AudioData");
                audioData.Edit();
            }
        }
    }
}

