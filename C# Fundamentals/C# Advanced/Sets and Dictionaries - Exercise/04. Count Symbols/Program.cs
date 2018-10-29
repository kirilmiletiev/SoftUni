using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            var input = Console.ReadLine();

            foreach (char c in input)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c] += 1;
                }
            }

            foreach (KeyValuePair<char, int> keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value} time/s");
            }
        }
    }
}
