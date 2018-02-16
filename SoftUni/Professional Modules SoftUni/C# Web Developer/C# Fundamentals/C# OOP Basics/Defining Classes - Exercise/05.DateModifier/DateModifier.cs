
using System;

public class DateModifier
{
    public DateModifier(string startDate, string endDate)
    {
        DateTime start = DateTime.Parse(startDate);
        DateTime end = DateTime.Parse(endDate);
        var result = (start-end);
        Console.WriteLine(Math.Abs(result.Days));

    }
}
