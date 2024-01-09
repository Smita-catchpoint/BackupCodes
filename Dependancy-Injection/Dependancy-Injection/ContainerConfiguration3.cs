
//using System;
//namespace Dependancy_Injection
//{         //ProperyBased DI-->manually
//    public interface IData
//    {
//        void Edit();

//    }
//    public class TextData : IData
//    {
//        public void Edit()
//        {
//            Console.WriteLine("Edit text data");
//        }
//    }
//    public class AudioData: IData
//    {
//        public void Edit()
//        {
//            Console.WriteLine("Edit Audio data");
//        }
//    }

//    public class Data
//    {
//        public IData s1 { get; set; }

//        public void PrintData()
//        {
//            s1.Edit();
//        }
//    }
//    class ContainerConfiguration3
//    {
//        static void Main(string[] args)
//        {
//            Data r = new Data();
//            r.s1 = new TextData();
//            r.PrintData();

//            Data c = new Data();
//            c.s1 = new AudioData();
//            c.PrintData();
//        }
//    }


//}


//using Autofac;


//namespace Dependancy_Injection
//{         //ProperyBased DI with autofac
//    public interface IData
//    {
//        void Edit();

//    }
//    public class TextData : IData
//    {
//        public void Edit()
//        {
//            Console.Write("Edit text data");
//        }
//    }
//    public class AudioData : IData
//    {
//        public void Edit()
//        {
//            Console.Write("Edit Audio data");
//        }
//    }

//    public class Data
//    {
//        public IData s1 { get; set; }

//        public void PrintData()
//        {
//            if (s1 != null)
//            {
//                Console.Write("Data:");
//                s1.Edit();
//            }
//            else
//            {
//                Console.WriteLine("no data available");
//            }
//        }
//    }
//    class ContainerConfiguration3
//    {
//        static void Main(string[] args)
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.RegisterType<TextData>().As<IData>();
//            builder.RegisterType<AudioData>().Named<IData>("AudioData");
//            builder.RegisterType<Data>().AsSelf();
//            var container = builder.Build();

//            //using (var scope = container.BeginLifetimeScope())
//            //{
//            //    var data = scope.Resolve<Data>();
//            //    data.s1 = scope.Resolve<IData>();
//            //    data.PrintData();
//            //}

//            using (var scope = container.BeginLifetimeScope())
//            {
//                var data = scope.Resolve<Data>();
//                data.s1 = scope.Resolve<IData>();
//                data.PrintData();

//                var audioData = scope.ResolveNamed<IData>("AudioData");

//               audioData.Edit();

//            }

//        }
//    }
//}



//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using Autofac.Features.AttributeFilters;
//using System;

//namespace Dependancy_Injection
//{
//    //ProperyBased DI with autofac
//    public interface IData
//    {
//        void Edit();
//    }
//    public class TextData : IData
//    {
//        public void Edit()
//        {
//            Console.WriteLine("Edit text data");
//        }
//    }
//    public class AudioData : IData
//    {
//        public void Edit()
//        {
//            Console.WriteLine("Edit audio data");
//        }
//    }

//    public class Data
//    {
//        [Named("text")]
//        public IData s1 { get; set; }

//        [Named("audio")]
//        public IData s2 { get; set; }

//        public void PrintData()
//        {
//            if (s1 != null && s2 != null)
//            {
//                Console.Write("Data: ");
//                s1.Edit();
//                s2.Edit();
//            }
//            else
//            {
//                Console.WriteLine("No data available");
//            }
//        }
//    }
//    class ContainerConfiguration3
//    {
//        static void Main(string[] args)
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.Register(c => new TextData()).Named<IData>("text");
//            builder.Register(c => new AudioData()).Named<IData>("audio");
//            builder.RegisterType<Data>().PropertiesAutowired();

//            var container = builder.Build();

//            var data = container.Resolve<Data>();
//            data.PrintData();
//        }
//    }
//}






//using Autofac;

//namespace Dependancy_Injection
//{         //ProperyBased DI with autofac
//    public interface IData
//    {
//        void Edit();

//    }
//    public class TextData : IData
//    {
//        public void Edit()
//        {
//            Console.Write("Edit text data");
//        }
//    }
//    public class AudioData : IData
//    {
//        public void Edit()
//        {
//            Console.Write("Edit Audio data");
//        }
//    }

//    public class Data
//    {
//        public IData s1 { get; set; }

//        public void PrintData()
//        {
//            if (s1 != null)
//            {
//                Console.Write("Data:");
//                s1.Edit();
//            }
//            else
//            {
//                Console.WriteLine("no data available");
//            }
//        }
//    }
//    class ContainerConfiguration3
//    {
//        static void Main(string[] args)
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.RegisterType<TextData>().As<IData>();
//            builder.RegisterType<AudioData>().As<IData>();
//            builder.RegisterType<Data>().AsSelf();
//            var container = builder.Build();

//            using (var scope = container.BeginLifetimeScope())
//            {
//                var data = scope.Resolve<Data>();
//                data.s1 = scope.Resolve<IData>();
//                data.PrintData();
//            }



//        }
//    }
//}
