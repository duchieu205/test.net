using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        product.Id = Guid.NewGuid();
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Products.ToList());
    }
}
