using System;

class Program
{
    static void Main(string[] args)
    {

        string name = Console.ReadLine();
        Ferrari ferrari = new Ferrari(name);
        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }

        Console.WriteLine(ferrari);
    }
}