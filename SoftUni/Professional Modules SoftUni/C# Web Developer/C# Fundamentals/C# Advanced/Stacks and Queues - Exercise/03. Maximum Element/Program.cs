using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<BigInteger> stack = new Stack<BigInteger>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];

                if (command=="1")
                {
                    var num = BigInteger.Parse(input[1]);
                    stack.Push(num);
                }
                else if (command == "2")
                {
                    stack.Pop();
                }
                else if (command == "3")
                {
                    Console.WriteLine(stack.Max());
                }
            }
        }
    }
}
