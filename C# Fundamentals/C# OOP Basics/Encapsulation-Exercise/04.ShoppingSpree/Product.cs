using System;
using System.Collections.Generic;
using System.Text;


public class Product
{

    public bool isValid = true;
    private string name;
    private decimal cost;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Name cannot be empty");
                isValid = false;
                return;
            }
            name = value;
        }
    }

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
                isValid = false;
                return;
            }
            cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
}
