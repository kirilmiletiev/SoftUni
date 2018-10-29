using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Func<int, int, bool> func = (n, d) => n % d == 0;
            GetPrint(number, dividers, func);
        }

        private static void GetPrint(int number, int[] dividers, Func<int, int, bool> func)
        {
            List<int> resultList = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                bool IsValid = true;
                foreach (int divider in dividers)
                {
                    if (!func(i, divider))
                    {
                        IsValid = false;
                    }
                }
                if (IsValid)
                {
                    resultList.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", resultList));

        }
    }
}/////
 //////