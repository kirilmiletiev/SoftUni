using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(input);
            var n = input.Length;

            for (int i = 0; i < n; i++)
            {
               // Console.Write(" ");
                Console.Write(stack.Pop());
                Console.Write(" ");
            }
        }
    }
}
