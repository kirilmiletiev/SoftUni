using System;
using System.Collections.Generic;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> dict = new Dictionary<int, BankAccount>();
        var input = Console.ReadLine();
        while (input != "End")
        {
            var commands = input.Split();
            var accountId = int.Parse(commands[1]);
            switch (commands[0])
            {
                case "Create":
                    if (dict.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        dict.Add(accountId, new BankAccount());
                    }
                    break;
                case "Deposit":
                    if (IsAccountExists(accountId, dict))
                    {
                        dict[accountId].Deposit(int.Parse(commands[2]));
                    }
                    break;
                case "Withdraw":
                    if (IsAccountExists(accountId,dict))
                    {
                        dict[accountId].WithDraw(int.Parse(commands[2]));
                    }
                    break;
                case "Print":
                    if (IsAccountExists(accountId, dict))
                    {
                        BankAccount.Id = accountId;
                        Console.WriteLine(dict[accountId]);
                    }
                    break;
                    default:
                    break;
            }
            input = Console.ReadLine();
        }
    }

    private static bool IsAccountExists(int accountId, Dictionary<int, BankAccount> dict)
    {
        if (dict.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}
