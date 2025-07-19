using FluentValidation;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Validators;

public class CreateProductValidator : AbstractValidator<Product>
{
    public CreateProductValidator(){
        {
            RuleFor(x => x.ProductCode)
                .NotEmpty().WithMessage("Product code is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.");
        }
    }
}