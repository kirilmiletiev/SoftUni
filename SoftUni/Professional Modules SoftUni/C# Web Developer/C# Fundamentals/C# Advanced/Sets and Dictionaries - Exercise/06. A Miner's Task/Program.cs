using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            var input = Console.ReadLine();

            while (input!="stop")
            {
                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, int.Parse(Console.ReadLine()));
                }
                else
                {
                    dict[input] += int.Parse(Console.ReadLine());
                }
                input= Console.ReadLine();
            }
            foreach (KeyValuePair<string, int> keyValuePair in dict)
            {
                //Console.WriteLine(keyValuePair);
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
