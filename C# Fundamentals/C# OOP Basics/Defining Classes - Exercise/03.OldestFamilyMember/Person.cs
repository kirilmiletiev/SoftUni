using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age) : this()
    {
        this.Age = age;
    }

    public Person(string name, int age) : this(age)
    {
        this.Name = name;
    }

    //private string name;
    //private int age;

    //public string Name
    //{
    //    get { return name; }
    //    set { name = value; }
    //}
    //public int Age
    //{
    //    get { return age; }
    //    set { age = value; }
    //}
}

