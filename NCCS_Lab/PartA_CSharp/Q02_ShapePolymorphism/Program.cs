using System;

class Shape
{
    public virtual double Area()
    {
        return 0;
    }
}

class Circle : Shape
{
    double radius;
    public Circle(double r) { radius = r; }
    public override double Area()
    {
        return 3.14159 * radius * radius;
    }
}

class Rectangle : Shape
{
    double length, width;
    public Rectangle(double l, double w) { length = l; width = w; }
    public override double Area()
    {
        return length * width;
    }
}

class Program
{
    static void Main()
    {
        Circle c = new Circle(5);
        Rectangle r = new Rectangle(4, 6);

        Shape shapeRef;

        shapeRef = c;
        Console.WriteLine("Area of Circle: " + shapeRef.Area());

        shapeRef = r;
        Console.WriteLine("Area of Rectangle: " + shapeRef.Area());
    }
}
