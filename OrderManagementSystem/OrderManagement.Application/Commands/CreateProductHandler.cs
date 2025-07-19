using MediatR;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand>
{
    private readonly ProductRepositoryInterface _repository;

    public CreateProductHandler(ProductRepositoryInterface repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            ProductCode = request.product_code,
            Name = request.name,
            Price = request.price,
            Unit = request.unit
        };
         await _repository.AddAsync(product);
    }
}
