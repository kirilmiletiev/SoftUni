using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> act = x =>
            {
                foreach (string s in x)
                {
                    Console.WriteLine($"Sir {s}");
                }
            };
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            act(input);
        }
    }
}
