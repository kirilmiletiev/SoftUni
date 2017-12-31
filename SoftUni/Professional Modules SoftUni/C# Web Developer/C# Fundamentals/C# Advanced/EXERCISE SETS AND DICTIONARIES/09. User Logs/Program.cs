using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            List<string> list = new List<string>();
            SortedDictionary<string, Dictionary<string, int>> dict = new SortedDictionary<string, Dictionary<string, int>>();
            var input = Console.ReadLine();

            while (input != "end")
            {
                var splittedInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var s in splittedInput)
                {
                    list.Add(s);
                }

                var ip = list[0].Split('=');
                var realIp = ip[1];
                var user = list[2].Split('=');
                var realUser = user[1];
                if (!dict.ContainsKey(realUser))
                {
                    dict.Add(realUser, new Dictionary<string, int>());
                    dict[realUser].Add(realIp, 1);
                }
                else
                {
                    if (!dict[realUser].ContainsKey(realIp))
                    {
                        dict[realUser].Add(realIp, 1);
                    }
                    else
                    {
                        dict[realUser][realIp]++;
                    }
                }
                list.Clear();
                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key}: ");
                foreach (var pair in keyValuePair.Value)
                {
                    counter++;
                    if (counter == keyValuePair.Value.Count)
                    {
                        Console.WriteLine($"{pair.Key} => {pair.Value}.");
                    }
                    else
                    {
                        Console.Write($"{pair.Key} => {pair.Value}, ");
                    }
                }
                counter = 0;
            }
        }
    }
}
