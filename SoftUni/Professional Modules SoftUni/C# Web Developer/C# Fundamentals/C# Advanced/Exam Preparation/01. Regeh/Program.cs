using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\[[a-zA-z]+<(\d+)REGEH(\d+)>[a-zA-z]+\]";
            var input = Console.ReadLine();
            var regex = new Regex(pattern);
            List<int> list = new List<int>();
            foreach (Match match in regex.Matches(input))
            {
                list.Add(int.Parse(match.Groups[1].Value));
                list.Add(int.Parse(match.Groups[2].Value));
            }
            int currentIndex = 0;
            foreach (int i in list)
            {
                currentIndex += i;
                int iDontLikeRegex = currentIndex % (input.Length - 1);

                Console.Write(input[iDontLikeRegex]);
            }
        }
    }
}
