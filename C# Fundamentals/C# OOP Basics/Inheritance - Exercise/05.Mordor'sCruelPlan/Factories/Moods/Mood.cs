using System;
using System.Collections.Generic;
using System.Text;

public abstract class Mood
{
    private int happinessPoints;

    public Mood(int happinessPoints)
    {
        this.happinessPoints = happinessPoints;
    }
}