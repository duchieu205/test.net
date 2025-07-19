using MediatR;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly OrderRepositoryInterface _orderRepository;

    public CreateOrderHandler(OrderRepositoryInterface orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderItems = request.Items.Select(item => new OrderItem
        {
            Id = Guid.NewGuid(),
            ProductCode = item.ProductCode,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        }).ToList();

        var totalAmount = orderItems.Sum(i => i.UnitPrice * i.Quantity);
        var vat = totalAmount * 0.1M;
        var grandTotal = totalAmount + vat;

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = request.CustomerName,
            CreatedAt = DateTime.Now,
            Items = orderItems
        };
    order.CalculateTotals();
        await _orderRepository.AddAsync(order);
    }
}
