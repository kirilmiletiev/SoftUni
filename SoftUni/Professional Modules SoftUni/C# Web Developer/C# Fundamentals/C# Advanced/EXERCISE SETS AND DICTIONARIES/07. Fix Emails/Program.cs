using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var name = Console.ReadLine();

            while (name != "stop")
            {
                var email = Console.ReadLine();

                if (!dict.ContainsKey(name))
                {
                    if (email.Contains("@") && !email.EndsWith(".us") && !email.EndsWith(".uk"))
                    {
                        dict.Add(name, email);
                    }

                }
                name = Console.ReadLine();
            }
            foreach (KeyValuePair<string, string> keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
