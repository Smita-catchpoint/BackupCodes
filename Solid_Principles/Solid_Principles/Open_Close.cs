using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    public interface Shape
    {
        double Area();
    }

    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double Area()
        {
            return Length * Width;
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }


    public class AreaCalculator
    {
        public double TotalArea(List<Shape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }
            return area;
        }
    }


    public class Open_Close
    {
        public static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle { Length = 10, Width = 5 });
            shapes.Add(new Circle { Radius = 3 });


            AreaCalculator calculator = new AreaCalculator();
            double totalArea = calculator.TotalArea(shapes);
            Console.WriteLine($"The total area is {totalArea}");

            foreach (var s in shapes)
            {

                string shapeName = s.GetType().Name;
                double shapeArea = s.Area();

                Console.WriteLine($"{shapeName} area is {shapeArea}");

            }
        }
    }
}
