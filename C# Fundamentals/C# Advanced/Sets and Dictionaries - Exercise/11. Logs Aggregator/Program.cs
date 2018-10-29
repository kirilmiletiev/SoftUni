using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> dict = new SortedDictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = input[0];
                var name = input[1];
                var duration = int.Parse(input[2]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new SortedDictionary<string, int>());
                    if (!dict[name].ContainsKey(ip))
                    {
                        dict[name].Add(ip, 0);
                        dict[name][ip] += duration;
                    }
                    else
                    {
                        dict[name][ip] += duration;
                    }
                }
                else
                {
                    if (!dict[name].ContainsKey(ip))
                    {
                        dict[name].Add(ip, 0);
                        dict[name][ip] += duration;
                    }
                    else
                    {
                        dict[name][ip] += duration;
                    }
                }

            }


            foreach (KeyValuePair<string, SortedDictionary<string, int>> keyValuePair in dict)
            {
                var sum = keyValuePair.Value.Values.Sum();
                //Console.WriteLine(keyValuePair.Key);
                
                    var reminder = "";
                    if (reminder != keyValuePair.Key)
                    {
                        Console.Write($"{keyValuePair.Key}: {sum} [");
                        Console.Write(string.Join(", ", keyValuePair.Value.Keys));
                        Console.WriteLine("]");
                        reminder = keyValuePair.Key;
                    }

                 
            }

        }
    }
}
