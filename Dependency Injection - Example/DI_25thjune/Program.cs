using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_25thjune
{

    class SavingAcc
    {
        public void PrintDetails()
        {
            Console.WriteLine("Saving Account");
        }
    }

    class CurrentAcc
    {
        public void PrintDetails()
        {
            Console.WriteLine("Current Account");
        }
    }

    class Acc
    {
        SavingAcc sa = new SavingAcc();
        CurrentAcc ca = new CurrentAcc();

        public void PrintAll()
        {
            sa.PrintDetails();
            ca.PrintDetails();
        }
    }

    class SavingAccount : IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Saving account details: ");
        }
    }

    class CurrentAccount : IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Current account details: ");
        }
    }

    interface IAccount
    {
        void PrintDetails();
    }

    class Account
    {
        /*
         * For Property Injection
        public IAccount account { get; set; }

        public void PrintAccount()
        {
            account.PrintDetails();
        }
        */

        /*
         * For Method Injection
        public void PrintAccount(IAccount account)
        {
            account.PrintDetails();
        }
        */

        /*
         * For Constructor Injection
        private IAccount account;
        public Account(IAccount account)
        {
            this.account = account;
        }
        public void PrintDetails()
        {
            account.PrintDetails();
        }
        */


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Acc acc = new Acc();
            acc.PrintAll();
            /*
             * For Property Injection
            Account sa = new Account();
            sa.account = new SavingAccount();
            sa.PrintAccount();
            sa.account = new CurrentAccount();
            sa.PrintAccount();
            */

            /*
             * For Method Injection
            Account sa = new Account();
            sa.PrintAccount(new SavingAccount());
            sa.PrintAccount(new CurrentAccount());
            */

            /*
             * For Constructor Injection

            IAccount ca2 = new SavingAccount();
            Account b = new Account(ca2);
            b.PrintDetails();

            IAccount ca = new CurrentAccount();
            Account a = new Account(ca);
            a.PrintDetails();
            */

            Console.ReadKey();
        }
    }
}
