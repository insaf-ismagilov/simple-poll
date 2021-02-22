using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Application.Profiles;

namespace SimplePoll.Api.Configurations
{
	public static class AutoMapperConfiguration
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			var profiles = new List<Profile>
			{
				new SimplePoll.Infrastructure.DataAccess.Profiles.UserProfile(),
				new Profiles.UserProfile(),
				new PollProfile()
			};
			
			var mapper = new MapperConfiguration(c => c.AddProfiles(profiles)).CreateMapper();

			services.AddSingleton(_ => mapper);
			
			return services;
		}
	}
}