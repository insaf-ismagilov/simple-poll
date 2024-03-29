﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Infrastructure.DataAccess;

namespace SimplePoll.Api.Configurations
{
	public static class DbConfiguration
	{
		public static IServiceCollection ConfigureDb(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("SimplePoll");

			var connectionProvider = new NpgSqlConnectionProvider(connectionString);

			services.AddSingleton<IDatabaseConnectionProvider>(_ => connectionProvider);
			services.AddTransient<IDatabaseRepository, DatabaseRepository>();

			return services;
		}
	}
}