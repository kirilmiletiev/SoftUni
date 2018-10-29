using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int i in input)
            {
                if (Math.Abs(i) % 3 == 0)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

            foreach (int i in input)
            {
                if (Math.Abs(i) % 3 == 1)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

            foreach (int i in input)
            {
                if (Math.Abs(i) % 3 == 2)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

        }
    }
}
