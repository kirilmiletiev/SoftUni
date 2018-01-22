using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var s = int.Parse(input[1]);
            var x = int.Parse(input[2]);

            var nums = (Console.ReadLine().Split());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                stack.Push(int.Parse(nums[i]));
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            
            if (stack.Count<=0) /// fix null case
            {
                Console.WriteLine("0");
                return;
            }
            
            
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                //stack.ToArray();
                Console.WriteLine(stack.Min());
            }

        }
    }
}
