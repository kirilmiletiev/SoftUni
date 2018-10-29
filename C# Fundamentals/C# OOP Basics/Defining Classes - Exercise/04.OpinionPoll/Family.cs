using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    public static List<Person> persons = new List<Person>();

    public static void AddMember(Person person)
    {
        if (!persons.Contains(person))
        {
            persons.Add(person);
        }
    }

    public static void GetOldestMember()
    {
        List<Person>perso = new List<Person>();
        var maxAge = int.MinValue;
        var maxName = "";
        foreach (var person in persons)
        {
            if (person.Age>30)
            {
                perso.Add(person);
            }
        }
        foreach (Person person in perso.OrderBy(x=>x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

