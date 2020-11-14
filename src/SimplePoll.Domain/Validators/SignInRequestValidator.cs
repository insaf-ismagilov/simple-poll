using FluentValidation;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Domain.Validators
{
	public class SignInRequestValidator : AbstractValidator<SignInRequest>
	{
		public SignInRequestValidator()
		{
			RuleFor(x => x.Email).EmailAddress();
		}
	}
}