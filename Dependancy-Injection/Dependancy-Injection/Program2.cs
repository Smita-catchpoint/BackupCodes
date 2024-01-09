
namespace Dependancy_Injection
{              //DI-MethodBased
    interface IAccount1
    {
        void PrintDetail();
    }
    class CurrentAccount1: IAccount1
    {
        public void PrintDetail()
        {
            Console.WriteLine("Details of CurrentAccount");
        }
    }
    class SavingAccount1: IAccount1 
    {
        public void PrintDetail()
        {
            Console.WriteLine("Details of SavingAccount");
        }

    }
    class Account1
    {
        public void PrintAccountDetails(IAccount1 account)
        {
            account.PrintDetail();
            Console.WriteLine("DI-MethodBased");
        }

    }
    internal class Program2
    {
        static void Main(string[] args)
        {
            Account1 account1 = new Account1();
            IAccount1 a = new SavingAccount1();
            account1.PrintAccountDetails(a);

            Console.WriteLine( );
            Account1 account2 = new Account1();
            IAccount1 a1 = new CurrentAccount1();
            account1.PrintAccountDetails(a1);

            Console.ReadLine();
        }
    }
}