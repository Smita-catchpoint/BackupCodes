using Autofac;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

//DI with autofac framework--->constructor 

namespace Dependancy_Injection
{   
    interface IHome
    {
        void StayAtHome();
        void defineHome();
    }
    interface ISchool
    {
        void AttendSchool();
    }
    class Home : IHome
    {
        public void defineHome()
        {
            Console.WriteLine("beautiful home..!");
        }

        public void StayAtHome()
        {
            Console.WriteLine("stay at home..!");
        }
    }
    class School : ISchool
    {
        public void AttendSchool()
        {
            Console.WriteLine("Attend School..!");
        }
    }
     
    class Person
    {
        private IHome home;
        private ISchool school;

        public Person(IHome home, ISchool school)
        {
            this.home = home;
            this.school = school;
        }
        public void Decide() {
            home.StayAtHome();
            school.AttendSchool();
            Console.WriteLine("make priorities");
        
        }

        public void myHome()
        {
            home.defineHome();
            Console.WriteLine("ohoo");

        }
    }
    internal class ContainerConfiguration
    {
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Home>().As<IHome>();
            builder.RegisterType<School>().As<ISchool>();
            builder.RegisterType<Person>();

            var container = builder.Build();


            var person = container.Resolve<Person>();
            person.Decide();
            person.myHome();

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var person = scope.Resolve<Person>();
            //    person.Decide();
            //}




        }
    }
}
