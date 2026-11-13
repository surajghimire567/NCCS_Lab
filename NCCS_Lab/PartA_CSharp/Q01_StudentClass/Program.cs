using System;

// Q1: Class Student with auto-implemented properties + constructor
class Student
{
    // Auto-implemented properties
    public string Name { get; set; }
    public int Roll { get; set; }
    public double Marks { get; set; }

    // Constructor initializing all three fields
    public Student(string name, int roll, double marks)
    {
        Name = name;
        Roll = roll;
        Marks = marks;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Roll: {Roll}, Marks: {Marks}");
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student("Suraj", 1, 85.5);
        Student s2 = new Student("Hari", 2, 72.0);

        s1.Display();
        s2.Display();
    }
}
