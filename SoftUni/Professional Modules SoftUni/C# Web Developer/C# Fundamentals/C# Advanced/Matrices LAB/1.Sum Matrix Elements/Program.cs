using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(new []{' ', ','}, StringSplitOptions
                .RemoveEmptyEntries);
            int [][] matrrix = new int[int.Parse(size[0])][];

            for (int i = 0; i < matrrix.Length; i++)
            {
                matrrix[i]= Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            int sum = 0;

            foreach (int[] ints in matrrix)
            {
                foreach (int i in ints)
                {
                    sum += i;
                }
               
            }

            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            Console.WriteLine(sum);
        }
    }
}
