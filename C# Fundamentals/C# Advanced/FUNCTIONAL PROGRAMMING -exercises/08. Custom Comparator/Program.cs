using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToArray().OrderBy(x => x);
            foreach (var i in input.OrderByDescending(x => (Math.Abs(x) % 2 == 0)).ThenByDescending(x => Math.Abs(x) % 2 == 1))
            {
                Console.Write($"{i} ");
            }

        }
    }
}
