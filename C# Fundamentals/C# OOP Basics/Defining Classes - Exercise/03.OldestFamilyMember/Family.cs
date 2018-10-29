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
        var maxAge = int.MinValue;
        var maxName = "";
        foreach (var person in persons)
        {
            if (person.Age > maxAge)
            {
                maxAge = person.Age;
                maxName = person.Name;
            }
        }
        Console.WriteLine($"{maxName} {maxAge}");
    }
}

