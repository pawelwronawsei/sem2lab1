namespace sem2lab3.Restaurant;

public class Menu
{
    public List<MenuItem> Items { get; set; }
    public DateOnly Published { get; init; }
    public List<Order> Orders { get; set; }

    public void PrintMenu()
    {
        
    }
}