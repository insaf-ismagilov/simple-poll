using FluentValidation;
using SimplePoll.Application.Models.Requests;

namespace SimplePoll.Application.Validators
{
	public abstract class SavePollOptionRequestValidator<T> : AbstractValidator<T> where T : SavePollOptionRequest
	{
		public SavePollOptionRequestValidator()
		{
			RuleFor(x => x.Text).NotEmpty();
			RuleFor(x => x.Value).NotEmpty();
		}
	}

	public class CreatePollOptionRequestValidator : SavePollOptionRequestValidator<CreatePollOptionRequest>
	{
	}

	public class UpdatePollOptionRequestValidator : SavePollOptionRequestValidator<UpdatePollOptionRequest>
	{
	}
}