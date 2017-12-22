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
            long sum = 0;
            var counter = 0;
            var n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            if (n == 1 || n == 0)
            {
                Console.WriteLine("1");
                return;
            }
            for (int i = 0; i < n-1; i++)
            {
                long one = stack.Peek();
                sum = stack.Pop() + stack.Pop();

                stack.Push(one);
                stack.Push(sum);

            }

            Console.WriteLine(sum);
        }
    }
}
