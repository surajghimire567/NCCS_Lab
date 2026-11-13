using System;
using System.Collections.Generic;

interface IPayable
{
    void Pay();
}

class Invoice : IPayable
{
    public double Amount;
    public Invoice(double amount) { Amount = amount; }
    public void Pay()
    {
        Console.WriteLine($"Invoice paid: Rs. {Amount}");
    }
}

class Salary : IPayable
{
    public string EmployeeName;
    public double Amount;
    public Salary(string name, double amount)
    {
        EmployeeName = name;
        Amount = amount;
    }
    public void Pay()
    {
        Console.WriteLine($"Salary paid to {EmployeeName}: Rs. {Amount}");
    }
}

class Program
{
    static void Main()
    {
        List<IPayable> payables = new List<IPayable>
        {
            new Invoice(1500),
            new Salary("Gita", 30000)
        };

        foreach (IPayable p in payables)
        {
            p.Pay(); // polymorphic call
        }
    }
}
