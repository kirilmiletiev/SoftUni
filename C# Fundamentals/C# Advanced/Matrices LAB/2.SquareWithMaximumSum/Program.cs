using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrx = new int[input[0]][];

            for (int i = 0; i < matrx.Length; i++)
            {
                matrx[i] = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            int maxSum = 0;

            string top = "";
            string down = "";

            for (int i = 0; i < matrx.Length - 1; i++)
            {
                for (int j = 0; j < matrx[i].Length - 1; j++)
                {
                    int topLeft = matrx[i][j];
                    int topRigt = matrx[i][j + 1];


                    int downLeft = matrx[i + 1][j];
                    int downRigt = matrx[i + 1][j + 1];

                    int currentSum = topLeft + topRigt + downLeft + downRigt;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        top = $"{topLeft} {topRigt}";
                        down = $"{downLeft} {downRigt}";
                    }
                }
            }

            Console.WriteLine(top);
            Console.WriteLine(down);
            Console.WriteLine(maxSum);

        }
    }
}
