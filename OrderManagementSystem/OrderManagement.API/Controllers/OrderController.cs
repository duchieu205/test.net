using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _db;

    public OrderController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        order.Id = Guid.NewGuid();
        order.CalculateTotals();

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return Ok(order);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] DateTime? from_date, [FromQuery] DateTime? to_date)
    {
        var query = _db.Orders.AsQueryable();

        if (from_date.HasValue)
            query = query.Where(o => o.CreatedAt >= from_date.Value);

        if (to_date.HasValue)
            query = query.Where(o => o.CreatedAt <= to_date.Value);

        return Ok(query.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var order = _db.Orders
            .Where(o => o.Id == id)
            .FirstOrDefault();

        if (order == null) return NotFound();

        return Ok(order);
    }
}
