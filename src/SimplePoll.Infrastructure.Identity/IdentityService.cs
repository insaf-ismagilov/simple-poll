using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimplePoll.Application.Contracts;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Enums;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Infrastructure.Authorization
{
	public class IdentityService : IIdentityService
	{
		private readonly IJwtGenerator _jwtGenerator;
		private readonly IPasswordHasher<User> _passwordHasher;
		private readonly IUserService _userService;

		public IdentityService(
			IUserService userService,
			IJwtGenerator jwtGenerator,
			IPasswordHasher<User> passwordHasher)
		{
			_userService = userService;
			_jwtGenerator = jwtGenerator;
			_passwordHasher = passwordHasher;
		}

		public async Task<ServiceResponse<AuthenticateResult>> SignInAsync(SignInRequest request)
		{
			var user = await _userService.GetByEmailAsync(request.Email);
			if (user == null)
				return ServiceResponse<AuthenticateResult>.Error();

			if (!VerifyHPassword(user, request.Password))
				return ServiceResponse<AuthenticateResult>.Error();

			var token = _jwtGenerator.GetToken(user);

			return ServiceResponse<AuthenticateResult>.Success(new AuthenticateResult
			{
				AccessToken = token
			});
		}

		public async Task<ServiceResponse> SignUpAsync(SignUpRequest request)
		{
			var user = await _userService.GetByEmailAsync(request.Email);
			if (user != null)
				return ServiceResponse.Error($"User with email \"{request.Email}\" already exists.");

			user = new User
			{
				Email = request.Email,
				Role = new UserRole {Id = UserRoleId.Regular}
			};
			user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

			var addResult = await _userService.AddAsync(user);

			return addResult;
		}

		private bool VerifyHPassword(User user, string providedPassword)
		{
			var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword);
			return result == PasswordVerificationResult.Success;
		}
	}
}