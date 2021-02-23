using FluentValidation;
using SimplePoll.Application.Models.Requests;

namespace SimplePoll.Application.Validators
{
	public class AddPollAnswerRequestValidator : AbstractValidator<AddPollAnswerRequest>
	{
		public AddPollAnswerRequestValidator()
		{
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.PollId).GreaterThan(0);
			RuleFor(x => x.PollOptionId).GreaterThan(0);
		}
	}
}