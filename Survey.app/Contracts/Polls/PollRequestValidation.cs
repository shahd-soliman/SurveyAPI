using FluentValidation;

namespace Survey.app.Contracts.Polls
{
    public class PollRequestValidation : AbstractValidator<PollRequest>
    {
        public PollRequestValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("Summary is required");
            RuleFor(x => x.StartAt).NotEmpty().WithMessage("Start date is required");
        }
    }
}
