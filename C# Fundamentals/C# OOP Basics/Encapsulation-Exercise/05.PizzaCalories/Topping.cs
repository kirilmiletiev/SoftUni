using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{
    private string type;
    private double weight;

    private string Type
    {
        get { return type; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce" )
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    private double Weight
    {
        get { return weight; }
        set
        {
            if (value<1 || value>50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }

    public Topping(string toppingType, double weight)
    {
        this.Type = toppingType;
        this.Weight = weight;
    }

    public double BackingTechCallories()
    {
        double modifier = 1.2; // defaut for Meat

        if (this.Type.ToLower() == "veggies")
        {
            modifier = 0.8;
        }
        else if (this.Type.ToLower() == "cheese")
        {
            modifier = 1.1;
        }
        else if(this.Type.ToLower() == "sauce")
        {
            modifier = 0.9;
        }else if (this.Type.ToLower() == "meat")
        {
            modifier = 1.2;
        }
        
        return (1 * this.Weight*2) * modifier;
    }


}
