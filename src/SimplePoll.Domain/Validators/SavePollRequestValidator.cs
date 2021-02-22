﻿using FluentValidation;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Domain.Validators
{
	public abstract class SavePollRequestValidator<T> : AbstractValidator<T> where T : SavePollRequest
	{
		public SavePollRequestValidator()
		{
			RuleFor(x => x.Title).NotEmpty();
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