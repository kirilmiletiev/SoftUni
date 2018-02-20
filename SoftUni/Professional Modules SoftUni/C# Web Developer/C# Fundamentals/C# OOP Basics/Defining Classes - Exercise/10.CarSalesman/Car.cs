﻿using System;
using System.Collections.Generic;
using System.Text;


public class Car
{

    private string model;
    private Engine engine;
    private double? weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public int Weight
    {
        set { this.weight = value; }
    }

    public string Color
    {
        set { this.color = value; }
    }

    public override string ToString()
    {
        var result = $"{this.model}:";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.engine.ToString());
        result = string.Concat(result, this.weight == null ? "  Weight: n/a" : $"  Weight: {this.weight}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.color == null ? "  Color: n/a" : $"  Color: {this.color}");
        result = string.Concat(result, Environment.NewLine);

        return result;
    }
}
