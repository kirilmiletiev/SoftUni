using System;

namespace _1.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n * 2 - 1; i++)
            {
                PrintRow(i, n);
                Console.WriteLine();
            }
        }

        private static void PrintRow(int i, int n)
        {
            if (i <= n)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(' ');
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
            }
            else
            {

                for (int j = 0; j < i - n; j++)
                {
                    Console.Write(" ");
                }

                for (int j = n; j > i - n; j--)
                {
                    Console.Write("* ");
                }
            }
        }
    }
}
