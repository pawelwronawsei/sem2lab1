using System.Numerics;

internal class Program
{
    public static void Main(string[] args)
    {
        // var head = new IntNode() { Data = 5, Next = new IntNode(){Data = 7, Next = new IntNode(){Data =  2}} };
        var names = new Node<String>() { Data = "Adam" };
        var stack = new WseiStack<string>();
        stack.Push("Adam");
        stack.Push("Ewa");
        stack.Push("Karol");
        Console.WriteLine(stack.Pop());
        
        // var stack2 = new WseiStack<double>();
        var stack2 = new WseiStackArray<double>();
        stack2.Push(5.1);
        stack2.Push(4.2);
        stack2.Push(7.8);

        double sum = 0;
        while (!stack2.IsEmpty())
        {
            sum += stack2.Pop();
        }
        Console.WriteLine(sum);

        // var box = new PizzaBox<PepperoniPizza>();
        // box.Print();

        //do tupli
        var r = GirlsAndBoys(new[] { "Adam", "Ewa", "Karol", "Beata" });
        Console.WriteLine($"Boys {r.Item1}");
        Console.WriteLine($"Girls {r.Item2}");
        
        (string name, int age) tuple = ("Adam", 23);
        Console.WriteLine(tuple);
    }

    //do tupli
    public static (int, int) GirlsAndBoys(IEnumerable<string> names)
    {
        int total = 0;
        int girls = 0;
        
        foreach (var name in names)
        {
            ++total;
            // girls += name.ToLower().EndsWith('a') ? 1 : 0;
            if (name.ToLower()[name.Length - 1] == 'a')
            {
                girls++;
            }
        }

        var result = new ValueTuple<int, int>(total - girls, girls);
        return result;
        // return (total - girls, girls);
    }
}

class PizzaBox<T> where T : Pizza, new()
{
    public T Content { get; set; } = new T() { Ingredients = new[] { "pane", "cheese" } };

    public void Print()
    {
        Console.WriteLine(string.Join(",", Content.Ingredients));
    }
}

class Pizza
{
    public string[] Ingredients { get; set; }
}

class PepperoniPizza : Pizza
{
    
}

interface IWseiStack<T>
{
    void Push(T item);
    T Pop();
}

class WseiStackArray<T> : IWseiStack<T>
{
    private T[] _array = new T[100];
    private int _last = -1;
    
    public void Push(T item)
    {
        if (_last < _array.Length)
        {
            _array[++_last] = item;
        }
        else
        {
            throw new Exception("Stack is full!");
        }
    }

    public T Pop()
    {
        if (_last > -1)
        {
            return _array[_last--];
        }
        else
        {
            throw new Exception("Stack is empty!");
        }
    }

    public bool IsEmpty()
    {
        return _last < 0;
    }
}

class WseiStack<T> : IWseiStack<T>
{
    private Node<T>? _top { get; set; }
    
    public void Push(T item)
    {
        //next = poprzednie
        _top = new Node<T>() { Data = item, Next = _top };
    }

    public bool IsEmpty()
    {
        return _top == null;
    }

    public T Pop()
    {
        if (_top == null)
        {
            throw new Exception("Stack is empty");
        }

        var data = _top.Data;
        _top = _top.Next;
        return data;
    }
}

class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

// class IntNode
// {
//     public int Data { get; set; }
//     public IntNode Next { get; set; }
// }
//
// class StringNode
// {
//     public string Data { get; set; }
//     public StringNode Next { get; set; }
// }