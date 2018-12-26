using FluentValidation;
using Piast.Web.Core.Models;

namespace Piast.Web.Core.Validators
{
    public class AdvertisementValidator : AbstractValidator<AdvertisementModel>
    {
        public AdvertisementValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty()
                .WithMessage("This field cannot be empty")
                .NotNull()
                .WithMessage("This field cannot be empty");
            RuleFor(x=>x.Description)
                .NotEmpty()
                .WithMessage("This field cannot be empty")
                .NotNull()
                .WithMessage("This field cannot be empty");
            RuleFor(x=>x.Price)
                .NotNull()
                .Must(y => y >=0)
                .WithMessage("This field cannot be on minus");
        }
    }
}