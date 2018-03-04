﻿using System;
using System.Collections.Generic;
using System.Text;

public class Repair : IRepair
{
    private string partName;
    private int hoursWorked;

    public Repair(string partName, int hoursWorked)
    {
        this.partName = partName;
        this.hoursWorked = hoursWorked;
    }

    public string PartName { get; private set; }

    public int HoursWorked { get; private set; }

    public override string ToString()
    {
        return $"Part Name: {this.partName} Hours Worked: {this.hoursWorked}";
    }
}