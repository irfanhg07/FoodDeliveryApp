using FluentValidation;

namespace DomainLayer.DTO.Request
{
    public class MenuItemRequestValidator : AbstractValidator<MenuItemRequest>
    {
        public MenuItemRequestValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("ItemName can't be empty")
                .MaximumLength(255).WithMessage("ItemName should be at most 255 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.RestaurantId)
                .GreaterThan(0).WithMessage("RestaurantId must be greater than zero");
        }
    }
}

