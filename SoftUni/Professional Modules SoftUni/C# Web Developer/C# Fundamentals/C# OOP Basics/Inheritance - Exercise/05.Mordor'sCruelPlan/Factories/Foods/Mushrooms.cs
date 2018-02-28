using System;
using System.Collections.Generic;
using System.Text;

public class Mushrooms : Food
{
    private const int PointsOfHappiness = -10;

    public Mushrooms() : base(PointsOfHappiness)
    {
    }
}