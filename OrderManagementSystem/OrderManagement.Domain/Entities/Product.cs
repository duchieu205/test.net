namespace OrderManagement.Domain.Entities;

public class Product
{
    public Guid id { get; set; }
    public string product_code { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }

    public string unit { get; set; }
}
