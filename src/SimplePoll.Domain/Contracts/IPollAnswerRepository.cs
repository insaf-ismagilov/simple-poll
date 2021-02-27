using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Domain.Contracts
{
	public interface IPollAnswerRepository
	{
		Task<PollAnswer> GetByIdAsync(int id);
		Task<ICollection<PollAnswer>> GetByPollIdAsync(int pollId);
		Task<int> AddAnswerAsync(PollAnswer pollAnswer);
	}
}