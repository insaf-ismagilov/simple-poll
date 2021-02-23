using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Domain.Contracts.Repositories
{
	public interface IPollRepository
	{
		Task<int> CreateAsync(Poll poll);
		Task<int?> UpdateAsync(Poll poll);
		Task<Poll> GetByIdAsync(int id);
		Task<ICollection<Poll>> GetAllAsync();
	}
}