﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Validators;

namespace SimplePoll.Web.Configurations
{
	public static class FluentValidationConfiguration
	{
		public static IServiceCollection ConfigureValidators(this IServiceCollection services)
		{
			services.AddTransient<IValidator<SignInRequest>, SignInRequestValidator>();
			services.AddTransient<IValidator<SignUpRequest>, SignUpRequestValidator>();
			
			return services;
		}
	}
}