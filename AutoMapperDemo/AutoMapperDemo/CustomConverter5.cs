//using System;
//using AutoMapper;

//    public interface ITypeConverter<TSource, TDestination>
//    {
//        TDestination Convert(TSource source);
//    }

//    public class StringConverter : ITypeConverter<string, int>
//    {
//        public int Convert(string source)
//        {
//            if (int.TryParse(source, out int result))
//            {
//                return result;
//            }
//            else
//            {
//                Console.WriteLine("Conversion failed. Defaulting to 0.");
//                return 0;
//            }
//        }
//    }

//    public class ConverterExample
//    {
//        public void ConvertUsing<TTypeConverter, TSource, TDestination>(TSource source)
//            where TTypeConverter : ITypeConverter<TSource, TDestination>, new()
//        {
//            TTypeConverter converter = new TTypeConverter();
//            TDestination result = converter.Convert(source);

//            Console.WriteLine($"Conversion result: {result}");
//        }
//    }

//    class CustomConverter5
//    {
//        static void Main()
//        {
//            ConverterExample example = new ConverterExample();

   
//            example.ConvertUsing<StringConverter, string, int>("123");

            
//        }
//    }
