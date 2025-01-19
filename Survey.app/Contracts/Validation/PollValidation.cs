using FluentValidation;

namespace Survey.app.Contracts.Validation
{
    public class PollValidation :AbstractValidator<PollRequest>
    {
        public PollValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
