using System;

namespace _03.AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                var chick = new Chicken(name, age);
                if (chick.IsValid == false)
                {
                    return;
                }
                Console.WriteLine($"Chicken {chick.Name} (age {chick.Age}) can produce {chick.ProductPerDay()} eggs per day.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return;
            }
        }
    }
}
