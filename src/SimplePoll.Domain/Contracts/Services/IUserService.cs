using System.Threading.Tasks;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Domain.Contracts.Services
{
	public interface IUserService
	{
		Task<User> GetByIdAsync(int id);
		Task<User> GetByEmailAsync(string email);
		Task<ServiceResponse<int>> AddAsync(User user);
		Task<ServiceResponse<int>> UpdateAsync(User user);
	}
}