namespace OrderManagement.Domain.Entities;

public class OrderItem
{
    public Guid id { get; set; }
    public string product_code { get; set; }

    public int quantity { get; set; }

    public decimal unit_price { get; set; }
}