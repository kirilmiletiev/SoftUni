using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    public bool isValid = true;
    private decimal money;
    private string name;
    private List<Product> list;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
                Console.WriteLine("Name cannot be empty");
                isValid = false;
                return;
            }
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
                Console.WriteLine("Money cannot be negative");
                isValid = false;
                return;
            }
            money = value;
        }
    }

    public List<Product> List
    {
        get { return list; }
        set { list = value; }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.List = new List<Product>();
    }
}