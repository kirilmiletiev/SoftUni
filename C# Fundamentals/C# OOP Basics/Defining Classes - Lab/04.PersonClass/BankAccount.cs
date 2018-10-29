using System;
public class BankAccount
{
    public decimal Balance { get; set; }
    public static int Id { get; set; }

    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:F2}";
    }

    public void WithDraw(decimal amount)
    {
        if (Balance - amount < 0)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            Balance -= amount;
        }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }
}