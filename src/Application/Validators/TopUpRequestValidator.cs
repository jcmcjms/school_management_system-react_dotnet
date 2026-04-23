using Application.DTOs.Wallet;
using FluentValidation;

namespace Application.Validators;

public class TopUpRequestValidator : AbstractValidator<TopUpRequest>
{
    public TopUpRequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.")
            .LessThanOrEqualTo(10000).WithMessage("Amount cannot exceed 10,000.");

        RuleFor(x => x.Source)
            .IsInEnum().WithMessage("A valid transaction source is required.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}