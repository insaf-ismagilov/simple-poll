using System.Threading.Tasks;
using SimplePoll.Application.Contracts;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;

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
	}
}