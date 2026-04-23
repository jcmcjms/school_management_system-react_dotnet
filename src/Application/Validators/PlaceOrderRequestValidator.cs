using Application.DTOs.Orders;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators;

public class PlaceOrderRequestValidator : AbstractValidator<PlaceOrderRequest>
{
    public PlaceOrderRequestValidator()
    {
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Order must contain at least one item.")
            .Must(items => items.Count <= 20).WithMessage("Order cannot contain more than 20 items.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 10).WithMessage("Quantity must be between 1 and 10.");
        });

        RuleFor(x => x.ScheduledFor)
            .Must(date => date > DateTime.UtcNow)
            .WithMessage("Scheduled time must be in the future.")
            .When(x => x.OrderType == OrderType.PreOrder);

        RuleFor(x => x.ScheduledFor)
            .Must(date => date <= DateTime.UtcNow.AddDays(7))
            .WithMessage("Pre-orders can only be scheduled within the next 7 days.")
            .When(x => x.OrderType == OrderType.PreOrder && x.ScheduledFor.HasValue);

        RuleFor(x => x.PaymentMethod)
            .IsInEnum().WithMessage("A valid payment method is required.");
    }
}