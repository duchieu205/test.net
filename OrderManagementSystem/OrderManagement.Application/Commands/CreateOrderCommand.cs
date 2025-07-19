using MediatR;

namespace OrderManagement.Application.Commands;

public record OrderItemDto(string ProductCode, int Quantity, decimal UnitPrice);

public record CreateOrderCommand(string CustomerName, List<OrderItemDto> Items) : IRequest;
