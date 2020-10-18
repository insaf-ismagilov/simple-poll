using System.Threading.Tasks;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Infrastructure.DataAccess
{
	public class UserRepository : IUserRepository
	{
		public Task<User> GetAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<int> AddAsync(User user)
		{
			throw new System.NotImplementedException();
		}

		public Task<int?> UpdateAsync(User user)
		{
			throw new System.NotImplementedException();
		}
	}
}