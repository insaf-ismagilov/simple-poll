using FluentValidation;
using SimplePoll.Application.Models.Requests;

namespace SimplePoll.Application.Validators
{
	public abstract class SavePollRequestValidator<T> : AbstractValidator<T> where T : SavePollRequest
	{
		public SavePollRequestValidator()
		{
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Status).IsInEnum();
			RuleFor(x => x.Type).IsInEnum();
		}
	}

	public class CreatePollRequestValidator : SavePollRequestValidator<CreatePollRequest>
	{
		public CreatePollRequestValidator()
		{
			RuleFor(x => x.Options).NotEmpty();
			RuleForEach(x => x.Options).SetValidator(new CreatePollOptionRequestValidator());
		}
	}

	public class UpdatePollRequestValidator : SavePollRequestValidator<UpdatePollRequest>
	{
		public UpdatePollRequestValidator()
		{
			RuleFor(x => x.Options).NotEmpty();
			RuleForEach(x => x.Options).SetValidator(new UpdatePollOptionRequestValidator());
		}
	}
}