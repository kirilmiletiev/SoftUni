using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;


public class Person
{

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

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



    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {salary:f2} leva.";
    }


    public Person(string firstName, string secondName)
    {
        this.FirstName = firstName;
        this.LastName = secondName;
    }

    public Person(string firstName, string lastName, int age)
        : this(firstName, lastName)
    {
        this.Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary)
        : this(firstName, lastName, age)
    {
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age > 30)
        {
            this.Salary += ((Salary / 100) * percentage);
        }
        else
        {
            this.Salary += ((Salary / 200) * percentage);
        }
    }
}
