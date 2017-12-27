using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> name = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //var input = Console.ReadLine();
                name.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join(" \n" , name));
        }
    }
}
