using System;

abstract class Employee
{
    public string Name;
    public Employee(string name) { Name = name; }

    public abstract double CalculateSalary();

    public void DisplaySalary()
    {
        Console.WriteLine($"{Name}'s Salary: {CalculateSalary()}");
    }
}

class Manager : Employee
{
    private double baseSalary = 50000;
    private double bonus = 10000;
    public Manager(string name) : base(name) { }
    public override double CalculateSalary() => baseSalary + bonus;
}

class Clerk : Employee
{
    private double baseSalary = 25000;
    private double allowance = 3000;
    public Clerk(string name) : base(name) { }
    public override double CalculateSalary() => baseSalary + allowance;
}

class Program
{
    static void Main()
    {
        Employee e1 = new Manager("Ram");
        Employee e2 = new Clerk("Sita");

        e1.DisplaySalary();
        e2.DisplaySalary();
    }
}
