using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToList();
            var oddEven = Console.ReadLine();
            for (long i = input[0]; i <= input[1]; i++)
            {
                if (oddEven == "even")
                {
                    if (Math.Abs(i) % 2 == 0)
                    {
                        Console.Write($"{i} ");
                    }
                }
                else if (oddEven == "odd")
                {
                    if (Math.Abs(i) % 2 == 1)
                    {
                        Console.Write($"{i} ");
                    }

                }
            }
        }
    }
}
