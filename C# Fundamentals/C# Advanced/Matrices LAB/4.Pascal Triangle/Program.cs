using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] matrx = new long[n][];

            for (int i =0; i < n; i++)
            {
                matrx[i]= new long[i+1];
                matrx[i][matrx[i].Length - 1] = 1;
                matrx[i][0] = 1;

                for (int j = 1; j < matrx[i].Length-1; j++)
                {
                    matrx[i][j] =  matrx[i - 1][j-1]
                                 + matrx[i - 1][j ]; 
                }
            }

            foreach (long[] ints in matrx)
            {
                foreach (long i in ints)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
    }
}
