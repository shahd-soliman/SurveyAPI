using FluentValidation;

namespace Survey.app.Contracts.Users
{
    public class AuthRequestValidation : AbstractValidator<AuthRequest>
    {
        public AuthRequestValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
