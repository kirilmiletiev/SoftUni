using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var data = Console.ReadLine();

            while (data!= "search")
            {
                var splittedInput = data.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(splittedInput[0]))
                {
                    dict.Add(splittedInput[0], splittedInput[1]);
                }
                else
                {
                    dict[splittedInput[0]] = splittedInput[1];
                }

                data = Console.ReadLine();
            }

            var searchedItem = Console.ReadLine();
            while (searchedItem != "stop")
            {
                if (dict.ContainsKey(searchedItem))
                {
                   // Console.WriteLine(dict[searchedItem] + " -> " dict.Values);
                    foreach (KeyValuePair<string, string> keyValuePair in dict)
                    {
                        Console.WriteLine($"{searchedItem} -> {dict[searchedItem]}");
                        break;

                    }
                }
                else
                {
                    Console.WriteLine($"Contact {searchedItem} does not exist.");
                }
                searchedItem = Console.ReadLine();
            }
        }
    }
}
