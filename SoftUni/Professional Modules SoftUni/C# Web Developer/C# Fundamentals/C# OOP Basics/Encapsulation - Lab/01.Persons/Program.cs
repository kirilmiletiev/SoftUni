using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine().Split();

            var person = new Person(input[0], input[1], int.Parse(input[2]));
            persons.Add(person);
        }

        foreach (Person person in persons.OrderBy(n=>n.FirstName).ThenBy(a=>a.Age))
        {
            Console.WriteLine(person);
        }

    }
}
