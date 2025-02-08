using FluentValidation;

namespace Survey.app.Contracts.Users
{
    public class AuthRequestValidation : AbstractValidator<AuthRequest>
    {
        public AuthRequestValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
