using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> act = x =>
            {
                foreach (var VARIABLE in x)
                {
                    Console.WriteLine(VARIABLE);
                }
            };
            var name = Console.ReadLine().Split(' ');
            act(name);
        }
    }
}
