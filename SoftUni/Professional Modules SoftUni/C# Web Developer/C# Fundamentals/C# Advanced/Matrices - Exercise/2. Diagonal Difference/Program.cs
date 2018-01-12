using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrx = new int[size][];

            for (int i = 0; i < size; i++)
            {
                matrx[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int sumOne = 0;
            int sumTwo = 0;

            for (int i = 0; i < matrx.Length; i++)
            {
                for (int j = 0; j < matrx[j].Length; j++)
                {
                    sumOne += matrx[i][j + i];
                    sumTwo += matrx[i][matrx[i].Length - i - 1];
                    break;
                }
            }
            Console.WriteLine($"{Math.Abs(sumOne - sumTwo)}");
        }
    }
}
