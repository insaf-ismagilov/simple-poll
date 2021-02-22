using FluentValidation;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Domain.Validators
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