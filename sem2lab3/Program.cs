class Program
{
    public static void Main()
    {
        var picture = new List<Shape>();
        picture.Add(new Rectangle(){Width = 34, Height = 45});
        picture.Add(new Rectangle(){Width = 10, Height = 5});
        picture.Add(new Rectangle(){Width = 2, Height = 15});
        picture.Add(new Circle(){Radius = 4});
        
        CalculateAreas(picture);
    }

    public static void CalculateAreas(List<Shape> shapes)
    {
        double sum = 0;
        
        foreach (var shape in shapes) sum += shape.Area;

        Console.WriteLine($"Suma pól {sum}");
    }
}

interface I
{
    
}

abstract class Shape
{
    public abstract double Area { get; }
    public int Color { get; }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area
    {
        get => Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set;  }
    public override double Area
    {
        get => Math.PI * Radius * Radius;
    }
}