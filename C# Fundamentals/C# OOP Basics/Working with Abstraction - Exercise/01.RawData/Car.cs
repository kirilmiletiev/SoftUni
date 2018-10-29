using System.Collections.Generic;

public class Car
{
    public string Model;

    public Cargo Cargo;

    public Engine Engine;

    public Tire[] Tires;

    public Car(string model, Cargo cargo, Engine engine, Tire[] tires)
    {
        this.Model = model;
        this.Cargo = cargo;
        this.Engine = engine;
        this.Tires = tires;
    }
}