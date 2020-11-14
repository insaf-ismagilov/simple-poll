using FluentValidation;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Domain.Validators
{
	public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
	{
		public SignUpRequestValidator()
		{
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.FirstName).NotNull().NotEmpty();
			RuleFor(x => x.LastName).NotNull().NotEmpty();
			RuleFor(x => x.Password).MinimumLength(8);
			RuleFor(x => x.RepeatPassword).Must((request, repeatPassword) => repeatPassword == request.Password);
		}
	}
}