// See https://aka.ms/new-console-template for more information
namespace Lab02;
    
internal class Program
{
    public static void Main()
    {
        //var soap = new Product() { Name = "Fa", Price = 2.45m };
        Product soap = Product.Of(name: "Fa", price: 1.23m);
        //użycie enuma
        Currency curr = Currency.EUR;

        Money m1 = Money.Of(value: 12.4m, Currency.EUR);
        Money m2 = Money.Of(value: 3.5m, Currency.EUR);
        Money result = m1 + m2;
        Console.WriteLine(result.Value);
    }
}

public enum Currency
{
    USD = 1, EUR = 2, PLN = 3
}

public class Money
{
    public decimal Value { get; init; }
    public Currency Currency { get; init; }
    
    private Money(){}
    
    public static Money operator +(Money a, Money b){
        if (a.Currency == b.Currency)
        {
            return Money.Of(a.Value + b.Value, a.Currency);
        }

        throw new ArgumentException(message: "Both currency must be the same");
    }

    public static Money Of(decimal value, Currency currency)
    {
        if (value < 0) throw new ArgumentException(message: "Price cannot be negative!");

        return new Money(){Value = value, Currency = currency};
    }
}

public class Product
{
    public int Id { get; set; }
    private string _name;
    public string Name
    {
        get => _name;
        init
        {
            if (value.Length > 1)
            {
                _name = value;
            }
            else
            {
                throw new ArgumentException(message: "Invalid name!");
            }
        }
    }

    public decimal Price { get; init; }

    private Product()
    {
        
    }

    //do tworzenia obiektu
    public static Product Of(string name, decimal price)
    {
        if (name.Length < 2)
        {
            throw new ArgumentException(message: "Name cannot be empty!");
        }

        if (price < 0)
        {
            throw new ArgumentException(message: "Price cannot be negative!");
        }

        return new Product() { Name = name, Price = price };
    }
}