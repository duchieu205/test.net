namespace OrderManagement.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; } = "";
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Unit { get; set; } = "";
}
