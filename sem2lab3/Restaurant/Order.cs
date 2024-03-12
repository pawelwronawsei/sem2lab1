namespace sem2lab3.Restaurant;

public class Order
{
    public Menu Menu { get; init; }
    
    private List<OrderItem> _orderItems = new List<OrderItem>();

    public decimal Price { get => 0m; init{} }
    
    public void AddItem(MenuItem item)
    {
        _orderItems.Add(new OrderItem(){ MenuItem = item, Quantity = 1 });
    }
    
    public void DeleteItem(MenuItem item)
    {
        foreach (var orderItem in _orderItems)
        {
            if (orderItem.MenuItem.Equals(item))
            {
                _orderItems.Remove(orderItem);
            }
        }
    }
}