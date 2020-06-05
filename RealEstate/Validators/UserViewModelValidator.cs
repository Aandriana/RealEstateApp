using FluentValidation;
using RealEstate.ViewModels;

namespace RealEstate.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage("Password is reqiired");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
