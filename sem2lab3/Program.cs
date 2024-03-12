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
        
        var swimmings = new List<ISwimming>();
        swimmings.Add(new Duck());

        var flyables = new List<IFlyable>();
        flyables.Add(new Duck());

        ISwimmingBird bird = new Duck();
    }

    public static void CalculateAreas(List<Shape> shapes)
    {
        double sum = 0;
        
        foreach (var shape in shapes) sum += shape.Area;

        Console.WriteLine($"Suma pól {sum}");
    }
}

interface ISwimmingBird : IFlyable, ISwimming
{
    public void Tweet();
}

interface IFlyable
{
    void TakeOff();
    void Fly(int distance);
    void Land();
}

interface ISwimming
{
    void Swim();
}

class Plane : IFlyable
{
    public double FuelLevel { get; set; }
    public void TakeOff()
    {
        if (FuelLevel > 0)
        {
            Console.WriteLine("Airplane is taking off!");
        }
        else
        {
            throw new Exception("Airplane can't take off, no fuel.");
        }
    }

    public void Fly(int distance)
    {
        throw new NotImplementedException();
    }

    public void Land()
    {
        throw new NotImplementedException();
    }
}

// class Duck : IFlyable, ISwimming
class Duck : ISwimmingBird
{
    public bool IsAlive { get; set; }
    public void TakeOff()
    {
        if (IsAlive)
        {
            Console.WriteLine("Taking off!");
        }
        else
        {
            throw new Exception("Duck can't take off!");
        }
    }

    public void Fly(int distance)
    {
        throw new NotImplementedException();
    }

    public void Land()
    {
        throw new NotImplementedException();
    }

    public void Swim()
    {
        Console.WriteLine("Duck is swimming!");
    }

    public void Tweet()
    {
        Console.WriteLine("Tweet!");
    }
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