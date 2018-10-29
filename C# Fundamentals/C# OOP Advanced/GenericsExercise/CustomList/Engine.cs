using System;
using System.Collections.Generic;
using System.Text;


public class Engine 
{
    public void Run()
    {
        Bag<string> bag = new Bag<string>();
        var inp = Console.ReadLine();
        while (inp!="END")
        {
            var splitedInput = inp.Split();
            var command = splitedInput[0];

            switch (command)
            {
                case "Add":
                    bag.Add(splitedInput[1]);
                    break;
                case "Remove":
                    bag.Remove(int.Parse(splitedInput[1]));
                    break;
                case "Contains":
                    Console.WriteLine(bag.Contains(splitedInput[1]));
                    break;
                case "Swap":
                    bag.Swap(int.Parse(splitedInput[1]), int.Parse(splitedInput[2]));
                    break;
                case "Greater":
                    Console.WriteLine(bag.CountGreaterThan(splitedInput[1]));
                    break;
                case "Max":
                    Console.WriteLine(bag.Max());
                    break;
                case "Min":
                    Console.WriteLine(bag.Min());
                    break;
                case "Print":
                    foreach (var value in bag.List)
                    {
                        Console.WriteLine(value);
                    }
                    break;
                case "Sort":
                    bag.Sorter();
                    break;
            }

            inp = Console.ReadLine();
        }
    }
}