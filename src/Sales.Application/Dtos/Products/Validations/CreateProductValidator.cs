using FluentValidation;

namespace Sales.Application.Dtos.Products.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("The {PropertyName} is required")
                .MaximumLength(200).WithMessage("The {PropertyName} must not exceed 200 characters");

            RuleFor(r => r.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");

            RuleFor(r => r.Qty)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cannot be negative");
        }
    }
}
