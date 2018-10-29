using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]== '(')
                {
                    stack.Push(i.ToString());
                }

                if (input[i]==')')
                {
                    var startIndex = int.Parse(stack.Pop());
                    var str = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(str);
                }
            }
        }
    }
}
