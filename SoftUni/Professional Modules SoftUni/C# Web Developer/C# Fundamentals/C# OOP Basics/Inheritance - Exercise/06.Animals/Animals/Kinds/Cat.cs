﻿using System;
using System.Collections.Generic;
using System.Text;
using _06.Animals.Animals;

public class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }
}