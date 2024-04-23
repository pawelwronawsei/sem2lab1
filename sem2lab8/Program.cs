class Player
{
    public string Name { get; set; }
    public int Points { get; set; }
}

internal class Program
{
    private static List<string> names = new List<string>() { "Adam", "Ewa", "Karol", "Jan", "Tomasz", "Anna" };
    
    public static void Main(string[] args)
    {
        // Find3LetterNames(names).Print();
        // NamesThatStartWith(names, 'a').Print();
        FilterNames(names, Is3Letters).Print();
        FilterNames(names, IsStartsWithLetterA).Print();
        
        FilterNames(names, delegate(string name) { return name.Length % 2 == 0; }).Print();
        FilterNames(names, (name) => name.Length % 2 == 0).Print();

        FilterNamesPredicate(names, name => name.Length % 2 != 0).Print();
        
        Console.WriteLine(BinaryOperation(2.0, 6.5, Sum));

        ActionPredicateDemo();
        FuncDelegateDemo();
    }
    // ZADANIE 1
    
    // public static List<string> Find3LetterNames(List<string> items)
    // {
    //     List<string> result = new List<string>();
    //     
    //     foreach (string item in items)
    //     {
    //         if (Is3Letters(item))
    //         {
    //             result.Add(item);
    //         }
    //     }
    //
    //     return result;
    // }
    
    // public static List<string> NamesThatStartWith(List<string> items, char letter)
    // {
    //     List<string> result = new List<string>();
    //     
    //     foreach (var item in items)
    //     {
    //         if (IsStartsWithLetterA(item))
    //         {
    //             result.Add(item);
    //         }
    //     }
    //
    //     return result;
    // }
    
    public static bool Is3Letters(string item)
    {
        return item.Length == 3;
    }

    public static bool IsStartsWithLetterA(string item)
    {
        item = item.ToLower();
        return item.StartsWith('a');
    }
    
    // W FOREACH UŻYWAM WYBRANĄ FUNKCJĘ 
    public static List<string> FilterNames(List<string> items, StringFilter filter)
    {
        List<string> result = new List<string>();
        
        foreach (string item in items)
        {
            if (filter(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public static List<string> FilterNamesPredicate(List<string> items, Predicate<string> filter)
    {
        List<string> result = new List<string>();
        
        foreach (string item in items)
        {
            if (filter(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    // ZADANIE 2
    // DO BINARYOPERATOR
    public static double Sum(double a, double b)
    {
        return a + b;
    }
    
    public static double BinaryOperation(double a, double b, BinaryOperator operation)
    {
        return operation(a, b);
    }
    
    // ZADANIE 3
    public static void ActionPredicateDemo()
    {
        Action<string> print2 = toPrint => Console.WriteLine(toPrint);
        print2("Paweł");

        Action<int, string> repeat = (x, text) =>
        {
            for (int i = 0; i < x; i++)
            {
                print2(text);
            }
        };
        repeat(3, "test");
    }

    public static void FuncDelegateDemo()
    {
        Func<double, double, double> binaryOp = (a, b) => a + b;
        Console.WriteLine(binaryOp(2.0, 3.0));
        
        binaryOp = (a, b) => a * b;
        Console.WriteLine(binaryOp(2.0, 3.0));
        
        binaryOp = (a, b) => a / b;
        Console.WriteLine(binaryOp(10.0, 5.0));
        
        Func<double, double> power = x => x * x;
        Console.WriteLine(power(5.0));

        Func<string, double> parser = str => Double.Parse(str);
        Console.WriteLine(parser("5"));

        parser = a => a.Length;
        Console.WriteLine(parser("5052"));

        Func<string, Player> mapper = str =>
        {
            var points = str.Split(";");
            return new Player()
            {
                Name = points[0],
                Points = int.Parse(points[1])
            };
        };
    }
}

static class CollectionExtensions{
    public static void Print<T>(this IEnumerable<T> items)
    {
        Console.WriteLine(string.Join(", ", items));
    }
}

delegate bool StringFilter(string item);
delegate double BinaryOperator(double a, double b);
