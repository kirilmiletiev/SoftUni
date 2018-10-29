using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Queue<string> queue = new Queue<string>(input.Split(' '));
            var num = int.Parse(Console.ReadLine());

            while (queue.Count>1)
            {
                for (int i = 0; i < num-1; i++)
                {
                    queue.Enqueue(queue.Dequeue());

                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
