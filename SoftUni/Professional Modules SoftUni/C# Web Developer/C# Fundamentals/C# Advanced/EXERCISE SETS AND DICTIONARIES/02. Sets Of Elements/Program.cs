using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(input[0]) + int.Parse(input[1]);

            for (int i = 0; i < num; i++)
            {
                var n = Console.ReadLine();

                if (!set.Contains(n))
                {
                    set.Add(n);
                }
                else
                {
                    Console.Write(n + ' ');
                }
            }

        }
    }
}
