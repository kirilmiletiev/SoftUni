using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;


public class Person
{

    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }


    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    }


    public Person(string firstName, string secondName)
    {
        this.FirstName = firstName;
        this.LastName = secondName;

    }

    public Person(string firstName, string lastName, int age)
        :this(firstName, lastName)
    {
        this.Age = age;
    }
}
