using System;
using System.Collections.Generic;

namespace _03.Validation
{
    class Program
    {
        static void Main(string[] args)
        {

            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                persons.Add(person);
            }

            var bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}
