using System;

class Week
{
    private string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday",
                               "Thursday", "Friday", "Saturday" };

    // Indexer
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= days.Length)
                return "Invalid Index";
            return days[index];
        }
        set
        {
            if (index >= 0 && index < days.Length)
                days[index] = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Week week = new Week();

        Console.WriteLine(week[0]); // Sunday
        Console.WriteLine(week[3]); // Wednesday

        week[6] = "Holiday";
        Console.WriteLine(week[6]); // Holiday
    }
}
