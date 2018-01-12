using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrx = new int[size[0]][];

            for (int i = 0; i < matrx.Length; i++)
            {
                matrx[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            long maxSum = long.MinValue;

            int[] partOne = new int[3];
            int[] partTwo = new int[3];
            int[] partThr = new int[3];


            List<int> one = new List<int>();
            List<int> two = new List<int>();
            List<int> three = new List<int>();


            for (int i = 0; i < matrx.Length - 2; i++)
            {
                for (int j = 0; j < matrx[i].Length - 2; j++)
                {
                    long currentSum = 0;
                    currentSum += matrx[i][j] + matrx[i][j + 1] + matrx[i][j + 2] +
                                  matrx[i + 1][j] + matrx[i + 1][j + 1] + matrx[i + 1][j + 2] +
                                  matrx[i + 2][j] + matrx[i + 2][j + 1] + matrx[i + 2][j + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        one.Clear();
                        one.Add(matrx[i][j]);
                        one.Add(matrx[i][j + 1]);
                        one.Add(matrx[i][j + 2]);
                        two.Clear();
                        two.Add(matrx[i + 1][j]);
                        two.Add(matrx[i + 1][j + 1]);
                        two.Add(matrx[i + 1][j + 2]);
                        three.Clear();
                        three.Add(matrx[i + 2][j]);
                        three.Add(matrx[i + 2][j + 1]);
                        three.Add(matrx[i + 2][j + 2]);

                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
            Console.WriteLine(string.Join(" ", three));
        }
    }
}
