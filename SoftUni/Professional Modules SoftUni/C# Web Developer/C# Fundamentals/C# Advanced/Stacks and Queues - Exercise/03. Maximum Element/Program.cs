using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            long maxNum = long.MinValue;
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandDate = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                var command = (commandDate[0]);

                if (command == 1)
                {
                    stack.Push(commandDate[1]);
                    if (commandDate[1] > maxNum)
                    {
                        maxNum = commandDate[1];
                    }
                }
                else if (command == 2)
                {
                    if (stack.Peek() == maxNum)
                    {
                        stack.Pop();
                        if (stack.Count>0)
                        {
                            maxNum = stack.Max();
                        }
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                if (stack.Count == 0)
                {
                    maxNum = long.MinValue;
                }
                else if (command == 3)
                {
                    Console.WriteLine(maxNum);
                }
            }
        }
    }
}
