using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SimplePoll.Web.Configurations
{
	public static class AutoMapperConfiguration
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			var profiles = new List<Profile>
			{
				new SimplePoll.Infrastructure.DataAccess.Profiles.UserProfile(),
				new Profiles.UserProfile()
			};
			
			var mapper = new MapperConfiguration(c => c.AddProfiles(profiles)).CreateMapper();

			services.AddSingleton(x => mapper);
			
			return services;
		}
	}
}