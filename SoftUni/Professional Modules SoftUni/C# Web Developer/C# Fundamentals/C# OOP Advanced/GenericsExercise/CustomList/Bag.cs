using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Bag<T> where T : IComparable
{
   public List<T> List { get; set; }
  

    public Bag()
    {
        List = new List<T>();
    }

    public void Add(T element)
    {
        List.Add(element);
    }

    public T Remove(int index)
    {
        for (int i = 0; i < List.Count; i++)
        {
            if (i==index)
            {
                List.Remove(List[i]);
            }
            return List[i];
        }
        throw new ArgumentException("There is no such index in the List!");
    }

    public bool Contains(T element)
    {
        foreach (T value in List)
        {
            if (value.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {

        var rotate1 = List[index1];
        var rotate2 = List[index2];

        List[index1] = rotate2;
        List[index2] = rotate1;
        //var perffix = List[index1];
        //for (int i = 0; i < List.Count; i++)
        //{
        //    if (i==index1)
        //    {

        //    }
        //}
    }

    public int CountGreaterThan(T element)
    {
        int result = 0;
        foreach (T value in List)
        {
            var compare = value.CompareTo(element);
            if (compare>0)
            {
                result++;
            }
        }

        return result;
    }

    public T Max()
    {
        return List.Max();
       
    }

    public T Min()
    {
        return List.Min();
    }

    public List<T> Sorter()
    {
        List<T> newList = new List<T>(this.List.OrderBy(x => x));
        List = newList;
        return List;
    }
   
}