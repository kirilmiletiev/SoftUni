using System;
using System.Collections.Generic;
using System.Text;

public static class ArrayCreator
{

    //private static int Length { get; set; }
    //private static T Item { get; set; }

    public static T[] Create<T>(int length, T item)
    {
        return new T[length];
    }
}