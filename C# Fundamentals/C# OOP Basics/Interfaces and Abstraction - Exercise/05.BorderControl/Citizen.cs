using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IControl
{
    private string name;
    private int age;
    private string id;

    public Citizen(string name, int age, string id)
    {
        this.name = name;
        this.age = age;
        this.id = id;
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

}