using System;
using System.Collections.Generic;
using System.Text;


class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length<1 || value.Length>15 || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private List<Topping> toppings;

    public List<Topping> Toppings
    {
        get { return toppings; }
        set
        {
            //if (value.Count>10)
            //{
            //    throw new ArgumentException("Number of toppings should be in range [0..10].");
            //}
            toppings = value;
        }
    }

    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        private set { dough = value; }
    }

    private Topping topping;

    public Topping Topping
    {
        get { return topping; }
        private set { topping = value; }
    }

    public Pizza()
    {
        
    }

    public Pizza(string name)
        :this()
    {
        this.Name = name;
    }

   

    public Pizza(string name, Dough dough, List<Topping> toppings)
        :this(name)
    {
      //  this.Name = name;
        this.Dough = dough;
        this.Toppings = toppings;

    }

    public double TotalCalories(Pizza pizza)
    {
        var first = pizza.Dough.DoughCalories();
        var second = pizza.Topping.BackingTechCallories();
        return first + second;
    }

    //public static implicit operator Pizza((string pizzaName, Dough dought, List<Topping>) v)
    //{
    //    throw new NotImplementedException();
    //}
}
