using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Domain.Contracts
{
	public interface IUserRepository
	{
		Task<User> GetByIdAsync(int id);
		Task<User> GetByEmailAsync(string email);
		Task<int> AddAsync(User user);
		Task<int?> UpdateAsync(User user);
	}
}