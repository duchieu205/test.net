using System.Linq;
namespace OrderManagement.Domain.Entities;



public class Order
{
     public Guid Id { get; set; }
    public string CustomerName { get; set; } = "";
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalAmount { get; private set; }
    public decimal VAT { get; private set; }
    public decimal GrandTotal { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public void CalculateTotals()
    {
        TotalAmount = Items.Sum(i => i.Quantity * i.UnitPrice);
        VAT = TotalAmount * 0.1m;
        GrandTotal = TotalAmount + VAT;
    }

}