using Application.DTOs.Canteen;
using FluentValidation;

namespace Application.Validators;

public class CreateMenuItemRequestValidator : AbstractValidator<CreateMenuItemRequest>
{
    public CreateMenuItemRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.CostPrice)
            .GreaterThan(0).WithMessage("Cost price must be greater than zero.")
            .LessThanOrEqualTo(x => x.Price).WithMessage("Cost price cannot exceed selling price.");

        RuleFor(x => x.Category)
            .IsInEnum().WithMessage("A valid menu category is required.");

        RuleFor(x => x.PreparationTime)
            .InclusiveBetween(1, 120).WithMessage("Preparation time must be between 1 and 120 minutes.");
    }
}