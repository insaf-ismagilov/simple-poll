﻿using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SimplePoll.Infrastructure.Authorization;

namespace SimplePoll.Api.Configurations
{
	public static class AuthConfiguration
	{
		public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtSettingsSection = configuration.GetSection(nameof(JwtSettings));
			services.Configure<JwtSettings>(jwtSettingsSection);

			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtSettingsSection[nameof(JwtSettings.Issuer)],
						ValidAudience = jwtSettingsSection[nameof(JwtSettings.Audience)],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsSection[nameof(JwtSettings.SigningKey)]))
					};

					options.Events = new JwtBearerEvents
					{
						OnForbidden = c =>
						{
							var email = c.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
							var logger = services.BuildServiceProvider().GetService<ILogger<Startup>>();
							logger.LogError("Access denied for {Email}. Path: {Path}", email, c.HttpContext.Request.Path);
							return Task.CompletedTask;
						}
					};
				});

			return services;
		}
	}
}