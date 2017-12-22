using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            var counter = 0;
            var n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 0; i < n; i++)
            {
                var one = stack.Peek();
                sum = stack.Pop() + stack.Pop();
            }

            Console.WriteLine(sum);
        }
    }
}
