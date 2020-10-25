using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Application.Contracts
{
	public interface IUserService
	{
		Task<User> GetByIdAsync(int id);
	}
}