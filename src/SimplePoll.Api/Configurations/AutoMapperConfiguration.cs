using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimplePoll.Application.Profiles;
using SimplePoll.Infrastructure.DataAccess.Profiles;

namespace SimplePoll.Api.Configurations
{
	public static class AutoMapperConfiguration
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			var profiles = new List<Profile>
			{
				new UserProfile(),
				new Profiles.UserProfile(),
				new PollProfile(),
				new PollAnswerProfile(),
				new PollPreviewProfile()
			};

			var mapper = new MapperConfiguration(c => c.AddProfiles(profiles)).CreateMapper();

			services.AddSingleton(_ => mapper);

			return services;
		}
	}
}