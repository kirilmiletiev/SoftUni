using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            Console.WriteLine(string.Join("\n", input.Select((x => $"{x * 1.20:F2}"))));
        }
    }
}
