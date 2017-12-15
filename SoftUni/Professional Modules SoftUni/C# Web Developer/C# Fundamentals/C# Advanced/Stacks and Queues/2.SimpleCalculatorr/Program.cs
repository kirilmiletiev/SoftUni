using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SimpleCalculatorr
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count>1)
            {

                int first = int.Parse(stack.Pop());
                string plusMinus = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (plusMinus == "-")
                {
                    stack.Push((first-second).ToString());
                }
                else if(plusMinus == "+")
                {
                    stack.Push((first + second).ToString());
                }

            }
            Console.WriteLine(stack.Pop());
        }
    }
}
