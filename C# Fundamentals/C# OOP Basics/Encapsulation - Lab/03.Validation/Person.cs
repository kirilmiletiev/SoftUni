using System;
using System.Collections.Generic;
using System.Data;
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
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }


    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }


    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    //private int n = 4;


    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }

            this.salary = value;
        }
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
