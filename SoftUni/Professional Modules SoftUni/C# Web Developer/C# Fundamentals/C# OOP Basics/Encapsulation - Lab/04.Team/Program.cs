using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
            persons.Add(person);
        }

        Team firstTeam = new Team("First team");
        Team secondTeam = new Team("Reserve team");
        foreach (Person p in persons)
        {
            if (p.Age < 40)
            {
                firstTeam.AddPlayer(p);
            }
            else
            {
                secondTeam.AddPlayer(p);
            }
        }

        Console.WriteLine(Team.Count(firstTeam, secondTeam));
    }
}
