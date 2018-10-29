using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numsToPush = input[0];
            var numsToPop = input[1];
            var numToCheck = input[2];

            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            else
            {



                if (queue.Contains(numToCheck))
                {
                    Console.WriteLine("true");

                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
