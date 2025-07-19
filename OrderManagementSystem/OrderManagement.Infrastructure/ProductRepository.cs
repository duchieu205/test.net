using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure;

public class ProductRepository : ProductRepositoryInterface
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
