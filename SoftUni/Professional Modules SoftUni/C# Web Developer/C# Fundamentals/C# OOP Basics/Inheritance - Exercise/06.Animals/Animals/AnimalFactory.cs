﻿using System;
using System.Collections.Generic;
using System.Text;
using _06.Animals.Animals;
using _06.Animals;

public class AnimalFactory
{
    public static Animal GetAnimal(string kind, string name, int age, string gender = null)
    {
        switch (kind)
        {
            case "Dog":
                return new Dog(name, age, gender);
            case "Cat":
                return new Cat(name, age, gender);
            case "Frog":
                return new Frog(name, age, gender);
            case "Kitten":
                return new Kitten(name, age);
            case "Tomcat":
                return new Tomcat(name, age);
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}