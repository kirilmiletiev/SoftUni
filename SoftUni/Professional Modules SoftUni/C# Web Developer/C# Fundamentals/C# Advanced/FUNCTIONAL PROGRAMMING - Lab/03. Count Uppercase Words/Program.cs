using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var input = Console.ReadLine()
                .Split(new[] {" ", "\n",  "\r", "\t"}, StringSplitOptions.RemoveEmptyEntries);
        
            Console.WriteLine(string.Join("\n", input.Where(w=>char.IsUpper(w[0]))));
        }
    }
}
