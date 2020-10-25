using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Application;
using SimplePoll.Application.Contracts;
using SimplePoll.Domain.Contracts;
using SimplePoll.Infrastructure.DataAccess.Repositories;

namespace SimplePoll.Web.Configurations
{
	public static class DiConfiguration
	{
		public static IServiceCollection ConfigureDi(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUserService, UserService>();

			return services;
		}
		
	}
}