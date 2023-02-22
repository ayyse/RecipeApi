using FluentValidation;
using RecipeApi.Models;

namespace RecipeApi.Validators
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.PhotoUrl).NotEmpty();
            RuleFor(x => x.Ingredients).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
