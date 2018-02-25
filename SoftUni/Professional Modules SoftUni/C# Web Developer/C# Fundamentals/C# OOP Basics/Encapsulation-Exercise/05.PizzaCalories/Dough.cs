using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;


public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    private string FlourType
    {
        get { return flourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value;
        }
    }

    private string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value;
        }
    }

   

    private double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public Dough(string flowerType, string backingTechnique, double weight)
    {
        this.FlourType = flowerType;
        this.BakingTechnique = backingTechnique;
        this.Weight = weight;
    }
    

    public double DoughCalories()
    {
        double doughtModifier = 1.0;/// defaut value for Wholegrain!
        double techniqueModifier = 1.0; /// defaut value for Homemade

        if (this.flourType.ToLower() == "white")
        {
            doughtModifier = 1.5;
        }
        if (this.BakingTechnique.ToLower() == "crispy")
        {
            techniqueModifier = 0.9;
        }
        if (this.BakingTechnique.ToLower() == "chewy")
        {
            techniqueModifier = 1.1;
        }
        return (2 * this.weight) * doughtModifier * techniqueModifier;
    }
}