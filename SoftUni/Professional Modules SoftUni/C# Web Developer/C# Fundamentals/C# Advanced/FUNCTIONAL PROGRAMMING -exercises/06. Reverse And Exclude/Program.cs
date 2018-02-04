using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var divider = int.Parse(Console.ReadLine());
            foreach (int i in input.Reverse().Where(x => x % divider != 0))
            {
                Console.Write($"{i} ");
            }
        }
    }
}
