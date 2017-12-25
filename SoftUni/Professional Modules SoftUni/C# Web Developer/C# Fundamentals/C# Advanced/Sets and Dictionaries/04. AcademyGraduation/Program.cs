using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double[]>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, grades);
                }
            }

            foreach (var dictKey in dict.Keys.OrderBy(x=>x))
            {
                Console.WriteLine($"{dictKey} is graduated with {dict[dictKey].Average()}");
               
            }
        }
    }
}
