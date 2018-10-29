using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T>
{
    public Tuple<T, T, T> tuple;
    public T Item1 { get; protected set; }
    public T Item2 { get; protected set; }
    public T Item3 { get; protected set; }

    public Threeuple(T item1, T item2, T item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        this.tuple = new Tuple<T, T, T>(Item1, Item2, Item3);
    }


    public override string ToString()
    {
        return $"{Item1} -> {Item2} -> {Item3}";
    }
}