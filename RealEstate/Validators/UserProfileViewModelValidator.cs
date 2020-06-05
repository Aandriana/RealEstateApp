using FluentValidation;
using RealEstate.ViewModels;

namespace RealEstate.Validators
{
    public class UserProfileViewModelValidator : AbstractValidator<UserProfileViewModel>
    {
        public UserProfileViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.PhoneNumber).MinimumLength(10).MaximumLength(15);
        }
    }
}
