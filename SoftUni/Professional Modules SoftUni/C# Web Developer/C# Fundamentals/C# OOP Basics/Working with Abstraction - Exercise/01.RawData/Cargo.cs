using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
    public int cargoWeight;
    public string Type;

    public Cargo(int weight, string type)
    {
        this.cargoWeight = weight;
        this.CargoType = type;
    }

    public string CargoType { get => Type; set => Type = value; }
}