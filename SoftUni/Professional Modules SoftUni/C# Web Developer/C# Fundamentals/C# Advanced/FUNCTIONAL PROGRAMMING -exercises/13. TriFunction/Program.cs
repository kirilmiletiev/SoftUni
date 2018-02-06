using System;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int x = 0;
            foreach (string name in names)
            {
                foreach (char c in name)
                {
                    x += c;
                }
                if (x >= num)
                {
                    Console.WriteLine(name);
                    return;
                }
                x = 0;
            }
        }
    }
}