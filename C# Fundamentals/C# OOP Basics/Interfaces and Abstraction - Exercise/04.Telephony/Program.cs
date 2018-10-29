using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split();
        var urls = Console.ReadLine().Split();

        foreach (string number in numbers)
        {
            var phone = new Smartphone(number);
            Console.WriteLine(phone.Call(number));
        }

        foreach (string url in urls)
        {
            var brows = new Smartphone(url);
            Console.WriteLine(brows.Browse(url));
        }
    }
}
