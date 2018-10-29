using System;
using System.Linq;

namespace Functional_Programming___Lab
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0).OrderBy(x => x)));
        }
    }
}
