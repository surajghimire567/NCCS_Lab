using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 3, 8, 11, 14, 5, 20, 7, 16, 9, 24 };

        // LINQ query with lambda: even numbers > 10, sorted descending
        var result = numbers
                        .Where(n => n % 2 == 0 && n > 10)
                        .OrderByDescending(n => n)
                        .ToList();

        Console.WriteLine("Even numbers greater than 10 (descending):");
        foreach (var n in result)
            Console.WriteLine(n);
    }
}
