using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependancy_Injection
{
    public interface IEngine
    {
        void Start();

    }
    public class Engine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("DI-ConstructorBased");
        }
    }

     public class Car
    {
        private readonly IEngine _e1;
        public Car(IEngine e1)
        {
            _e1 = e1;
        }

        public void CarStart()
        {
            _e1.Start();
            Console.WriteLine("car started..");
        }

    }
    class ConstructorInjection
    {
        static void Main(string[] args)
        {
            Car car = new Car(new Engine());
            car.CarStart();
        }
    }


}
