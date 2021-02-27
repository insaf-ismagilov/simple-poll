using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Application;
using SimplePoll.Application.Contracts;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Infrastructure.Authorization;
using SimplePoll.Infrastructure.DataAccess.Repositories;

namespace SimplePoll.Api.Configurations
{
	public static class DiConfiguration
	{
		public static IServiceCollection ConfigureDi(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUserService, UserService>();
			services.AddSingleton<IJwtGenerator, JwtGenerator>();
			services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
			services.AddTransient<IIdentityService, IdentityService>();
			services.AddTransient<IPollRepository, PollRepository>();
			services.AddTransient<IPollService, PollService>();
			services.AddTransient<IPollAnswerRepository, PollAnswerRepository>();
			services.AddTransient<IPollAnswerService, PollAnswerService>();

			return services;
		}
	}
}