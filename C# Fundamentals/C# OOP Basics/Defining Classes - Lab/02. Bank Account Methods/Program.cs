using System;

namespace _02._Bank_Account_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();
            acc.Id = 1;
            acc.Deposit(15);
            acc.Withdraw(10);
            Console.WriteLine(acc);
        }
    }
}
