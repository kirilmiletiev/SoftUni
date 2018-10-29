using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Citizen> citizens = new List<Citizen>();
        List<Rebel> rebels = new List<Rebel>();
        int nubmerOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < nubmerOfPeople; i++)
        {
            var human = Console.ReadLine().Split();
            if (human.Length == 4)
            {
                var citizen = new Citizen(human[0], int.Parse(human[1]), human[2], human[3]);
                citizens.Add(citizen);
            }
            else if (human.Length == 3)
            {
                var rebel = new Rebel(human[0], int.Parse(human[1]), human[2]);
                rebels.Add(rebel);
            }
        }

        var name = Console.ReadLine();
        while (name != "End")
        {
            foreach (Citizen citizen in citizens)
            {
                if (citizen.Name == name)
                {
                    citizen.BuyFood();
                }
            }

            foreach (Rebel rebel in rebels)
            {
                if (rebel.Name == name)
                {
                    rebel.BuyFood();
                }
            }
            name = Console.ReadLine();
        }
        Console.WriteLine(rebels.Select(x => x.Food).Sum() + citizens.Select(x => x.Food).Sum());
    }
}