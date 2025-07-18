using MediatR;

namespace OrderManagement.Application.Commands;

public record CreateProductCommand(string product_code, string name, decimal price, string unit) : IRequest;