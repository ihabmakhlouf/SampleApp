using FluentValidation;

namespace MyApp.Application.Commands;

public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
    public AddProductValidator()
        {
        RuleFor(x => x.Product.Name).NotNull()
                                    .NotEmpty().WithMessage("{PropertyName} is required.")
                                    .MinimumLength(3)
                                    .MaximumLength(250)
                                    .WithMessage("{PropertyName} must be fewer than 250 characters.");

        RuleFor(x => x.Product.Description).MaximumLength(1000)
                    .WithMessage("{PropertyName} must be fewer than 1000 characters.");

        }
    }

