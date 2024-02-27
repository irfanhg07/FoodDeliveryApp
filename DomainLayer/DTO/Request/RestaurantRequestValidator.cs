using FluentValidation;

namespace DomainLayer.DTO.Requests
{
    public class RestaurantRequestValidator : AbstractValidator<RestaurantRequest>
    {
        public RestaurantRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(255).WithMessage("Name length cannot exceed 255 characters");

            RuleFor(r => r.Description)
                .MaximumLength(1000).WithMessage("Description length cannot exceed 1000 characters");
        }
    }
}
