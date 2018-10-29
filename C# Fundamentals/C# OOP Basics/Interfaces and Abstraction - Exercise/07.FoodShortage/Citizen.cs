using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IControl, IBirthdate, IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    private int food;

    public int Food
    {
        get { return food; }
        set { food = value; }
    }


    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
        this.Food = food;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public void BuyFood()
    {
        this.Food += 10;
    }
}