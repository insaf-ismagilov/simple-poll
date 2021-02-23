using FluentValidation;
using SimplePoll.Application.Models.Requests;

namespace SimplePoll.Application.Validators
{
	public class SignInRequestValidator : AbstractValidator<SignInRequest>
	{
		public SignInRequestValidator()
		{
			RuleFor(x => x.Email).EmailAddress();
		}
	}
}