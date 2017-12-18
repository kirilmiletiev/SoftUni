using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecimalToBinaryConverter
{
    class Converter     
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            while (n >0)
            {
                stack.Push(n%2);

                n = n / 2;
            }
            int stacker = stack.Count;

            for (int i = 0; i < stacker; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
