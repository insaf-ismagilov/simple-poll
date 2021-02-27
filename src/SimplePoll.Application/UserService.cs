using System.Threading.Tasks;
using SimplePoll.Application.Contracts;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public Task<User> GetByIdAsync(int id)
		{
			return _userRepository.GetByIdAsync(id);
		}

		public Task<User> GetByEmailAsync(string email)
		{
			return _userRepository.GetByEmailAsync(email);
		}

		public async Task<ServiceResponse<int>> AddAsync(User user)
		{
			var newId = await _userRepository.AddAsync(user);
			return newId <= 0
				? ServiceResponse<int>.Error()
				: ServiceResponse<int>.Success(newId);
		}

		public async Task<ServiceResponse<int>> UpdateAsync(User user)
		{
			var updatedId = await _userRepository.UpdateAsync(user);
			return !updatedId.HasValue
				? ServiceResponse<int>.Error()
				: ServiceResponse<int>.Success(updatedId.Value);
		}
	}
}