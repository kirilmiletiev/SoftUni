using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<double, int>();

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var token in input)
            {
                if (!dict.ContainsKey(token))
                {
                    dict.Add(token, 1);
                }
                else
                {
                    dict[token] += 1;
                }
            }

            foreach (KeyValuePair<double, int> keyValuePair in dict)
            {
                Console.Write($"{keyValuePair.Key} - ");
                Console.WriteLine($"{keyValuePair.Value} times");
            }

        }
    }
}
