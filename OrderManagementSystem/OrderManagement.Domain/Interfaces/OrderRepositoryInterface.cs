using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces;

public interface OrderRepositoryInterface
{
    Task AddAsync(Order order);
}
