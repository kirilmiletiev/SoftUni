using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IBirthable, IIdentifiable, IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }
}