using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Validators;

namespace SimplePoll.Api.Configurations
{
	public static class FluentValidationConfiguration
	{
		public static IServiceCollection ConfigureValidators(this IServiceCollection services)
		{
			services.AddTransient<IValidator<SignInRequest>, SignInRequestValidator>();
			services.AddTransient<IValidator<SignUpRequest>, SignUpRequestValidator>();
			services.AddTransient<IValidator<CreatePollRequest>, CreatePollRequestValidator>();
			services.AddTransient<IValidator<CreatePollOptionRequest>, CreatePollOptionRequestValidator>();
			services.AddTransient<IValidator<UpdatePollRequest>, UpdatePollRequestValidator>();
			services.AddTransient<IValidator<UpdatePollOptionRequest>, UpdatePollOptionRequestValidator>();
			services.AddTransient<IValidator<AddPollAnswerRequest>, AddPollAnswerRequestValidator>();
			
			return services;
		}
	}
}