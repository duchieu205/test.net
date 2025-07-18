namespace OrderManagement.Domain.Entities;


public class Order
{
    public Guid id { get; set; }
    public string customer_name { get; set; }

    public decimal total_amount { get; private set; }

    public decimal vat { get; private set; }

    public decimal grand_total { get; private set; }

    public DateTime create_at { get; set; } = DateTime.UtcNow;

    public List<OrderItem> Items { get; set; } = new();

    public void calculate()
    {
        total_amount = Items.sum(x => x.quantity * x.unit_price);
        vat = total_amount * 0.10m;
        grand_total = total_amount + vat;
    }

}