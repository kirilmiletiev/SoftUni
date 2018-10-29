using System;
using System.Collections.Generic;
using System.Text;


public  class Animal
{
    private string Name { get; set; }
    private string FavouriteFood { get; set; }

    protected Animal( string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this.Name} and my favorite food is {this.FavouriteFood}";
    }
}