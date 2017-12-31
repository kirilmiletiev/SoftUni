using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>>  dict = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input!="report")
            {
                var splittedInput = input.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

                var city = splittedInput[0];
                var country = splittedInput[1];
                var population = int.Parse(splittedInput[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, long>());
                    dict[country].Add(city, population);
                }
                else
                {
                    if (!dict[country].ContainsKey(city))
                    {
                        dict[country].Add(city,population);
                    }
                    else
                    {
                        dict[country][city] += population;
                    }
                }
                input = Console.ReadLine();

            }

            foreach (KeyValuePair<string, Dictionary<string, long>> keyValuePair in dict.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                long totalPop = 0;

                foreach (KeyValuePair<string, long> valuePair in keyValuePair.Value)
                {
                    totalPop += valuePair.Value;
                }

                Console.WriteLine($"{keyValuePair.Key} (total population: {totalPop})");

                foreach (var pair in keyValuePair.Value.OrderBy(x=>x.Value).Reverse())
                {
                    Console.WriteLine($"=>{pair.Key}: {pair.Value}");
                }
                
            }
        }
    }
}
