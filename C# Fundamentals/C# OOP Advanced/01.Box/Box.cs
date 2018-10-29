using System;
using System.Collections;
using System.Collections.Generic;


public class Box<T>
{

    public Box()
    {
        this.Stack = new Stack<T>();
    }

    private Stack<T> Stack;
    

    public void Add(T element)
    {
        Stack.Push(element);
    }


    public object Remove()
    {
        if (Stack.Count>0)
        {
           return  Stack.Pop();
        }
        throw new ArgumentException("Box is empty.");
        
    }

    public int Count => Stack.Count;
}