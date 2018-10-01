using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _01.URLDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(input));


        }
    }
}
