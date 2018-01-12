using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[][] matrx = new string[size[0]][];

            for (int i = 0; i < size[0]; i++)
            {
                matrx[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < size[0] - 1; i++)
            {
                for (int j = 0; j < size[1] - 1; j++)
                {
                    if (matrx[i][j] == matrx[i][j + 1] && matrx[i + 1][j] == matrx[i + 1][j + 1] && matrx[i][j] == matrx[i + 1][j + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
