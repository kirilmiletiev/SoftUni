using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SortedDictionary<string, long> dict = new SortedDictionary<string, long>();
            SortedDictionary<string, long> junkDict = new SortedDictionary<string, long>();
            dict.Add("motes", 0);
            dict.Add("shards", 0);
            dict.Add("fragments", 0);
            bool getData = true;
            string theItem = "";

            while (getData)
            {
                var input = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        if (input[i] == "fragments" || input[i] == "shards" || input[i] == "motes")
                        {
                            dict[input[i]] += long.Parse(input[i - 1]);

                            if (dict[input[i]]>=250 && input[i]== "shards")
                            {
                                getData = false;
                                dict[input[i]] -= 250;
                                theItem = "Shadowmourne";
                                break;
                            }else if (dict[input[i]] >= 250 && input[i] == "fragments")
                            {
                                getData = false;
                                dict[input[i]] -= 250;
                                theItem = "Valanyr";
                                break;
                            }
                            else if(dict[input[i]] >= 250 && input[i] == "motes")
                            {
                                getData = false;
                                dict[input[i]] -= 250;
                                theItem = "Dragonwrath";
                                break;
                            }
                        }
                        else
                        {
                            if (!junkDict.ContainsKey(input[i]))
                            {
                                junkDict.Add(input[i], new long());
                                junkDict[input[i]] += long.Parse(input[i - 1]);
                                if (junkDict[input[i]] >= 250)
                                {
                                    getData = false;
                                    junkDict[input[i]] -= 250;
                                    break;
                                }
                            }
                            else
                            {
                                junkDict[input[i]] += long.Parse(input[i - 1]);
                                if (junkDict[input[i]] >= 250)
                                {
                                    getData = false;
                                    junkDict[input[i]] -= 250;
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            Console.WriteLine($"{theItem} obtained!");
           foreach (KeyValuePair<string, long> keyValuePair in dict.OrderByDescending(x=>x.Value).ThenBy(y=>y.Key))
           {
               Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");

           }
           foreach (var i in junkDict.OrderBy(x=>x.Key))
           {
               Console.WriteLine($"{i.Key}: {i.Value}");
           }
        }
    }
}