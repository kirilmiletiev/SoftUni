using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var rows = int.Parse(input[0]);
            var columns = int.Parse(input[1]);

            for (int i = 0; i < rows; i++)
            {
                char startLetter = alphabet[i];

                for (int j = 0; j < columns; j++)
                {
                    char middLeter = alphabet[j + i];
                    Console.Write($"{startLetter}{middLeter}{startLetter} ");
                }
                Console.WriteLine();
            }
        }
    }
}
