using System;
using System.Linq;

namespace _05.Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.Eat(Console.ReadLine()
                .Split()
                .Where(fn => fn != string.Empty)
                .Select(fn => FoodFactory.GetFood(fn)));

            Console.WriteLine(player);
        }
    }
}