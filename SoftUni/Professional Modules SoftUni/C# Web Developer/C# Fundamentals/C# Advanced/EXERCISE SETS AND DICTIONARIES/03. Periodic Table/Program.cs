using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>(); 
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var element = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var s in element)
                {
                    if (!set.Contains(s))
                    {
                        set.Add(s);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", set.OrderBy(x=>x)));
        }
    }
}
