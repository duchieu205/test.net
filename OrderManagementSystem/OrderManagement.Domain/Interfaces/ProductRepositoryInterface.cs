using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces;

public interface ProductRepositoryInterface
{
    Task AddAsync(Product product);
    Task<List<Product>> GetAllAsync();
}

