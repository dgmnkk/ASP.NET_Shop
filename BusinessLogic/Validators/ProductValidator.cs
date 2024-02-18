using FluentValidation;
using ShopApp.Data.Entities;

namespace ShopApp.Validators
{
	public class ProductValidator : AbstractValidator<Advertisement>
	{
		public ProductValidator() {
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("{PropertyName must contain content}");
			RuleFor(x => x.Price)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be null")
				.GreaterThanOrEqualTo(0)
				.WithMessage("{PropertyName} must be greater or equals to 0");
			RuleFor(x => x.Brand)
				.NotEmpty()
				.WithMessage("{PropertyName must contain content}");
			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("{PropertyName must contain content}");
		}

	}
}
