using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    Func<int, int> addFunc = x => x + 1;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = addFunc(input[i]);
                    }
                }
                else if (command == "multiply")
                {
                    Func<int, int> multiplyFunc = x => x * 2;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = multiplyFunc(input[i]);
                    }
                }
                else if (command == "subtract")
                {
                    Func<int, int> subtractFunc = x => x - 1;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = subtractFunc(input[i]);
                    }
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", input));
                }
                command = Console.ReadLine();
            }
        }
    }
}
