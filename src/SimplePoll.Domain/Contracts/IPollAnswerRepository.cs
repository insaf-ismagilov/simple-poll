using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Domain.Contracts.Repositories
{
	public interface IPollAnswerRepository
	{
		Task<PollAnswer> GetByIdAsync(int id);
		Task<int> AddAnswerAsync(PollAnswer pollAnswer);
	}
}