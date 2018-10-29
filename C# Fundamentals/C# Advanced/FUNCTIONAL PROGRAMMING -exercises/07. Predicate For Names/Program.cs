using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in names.Where(x => x.Length <= nameLenght))
            {
                Console.WriteLine(name);
            }
        }
    }
}
