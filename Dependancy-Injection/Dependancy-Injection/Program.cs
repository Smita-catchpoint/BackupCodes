//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dependancy_Injection
//{   //without DI-->- Tight Coupling
//    class CurrentAccount
//    {
//        public void PrintDetails()
//        {
//            Console.WriteLine("Details of CurrentAccount");
//        }
//    }
//    class SavingAccount
//    {
//        public void PrintDetails()
//        {
//            Console.WriteLine("Details of SavingAccount");
//        }

//    }
//    class Account
//    {
//        CurrentAccount ca = new CurrentAccount();
//        SavingAccount sa = new SavingAccount();

//        public void PrintAccountDetails()
//        {
//            ca.PrintDetails();
//            sa.PrintDetails();
//        }

//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Account account = new Account();
//            account.PrintAccountDetails();
//            Console.ReadLine();
//        }
//    }
//}


namespace Dependancy_Injection
{   //with DI-->ConstructorBased (loose Coupling)

    interface IAccount
    {
        void PrintDetails();

    }
   
    class CurrentAccount: IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details of CurrentAccount");
        }
    }
    class SavingAccount: IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details of SavingAccount");
        }

    }

    class Account
    {
        private IAccount account;
        public Account(IAccount account)
        {
            this.account = account;
        }
        public void PrintDetails() { 
            account.PrintDetails();
        
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            IAccount ac = new CurrentAccount();
            Account a = new Account(ac);
            a.PrintDetails();

            IAccount sa = new SavingAccount();
            Account a2 = new Account(sa);
            a2.PrintDetails();

            Console.ReadLine();
        }
    }
}

