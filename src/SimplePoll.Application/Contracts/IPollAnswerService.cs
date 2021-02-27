using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application.Contracts
{
	public interface IPollAnswerService
	{
		Task<PollAnswer> GetByIdAsync(int id);
		Task<ICollection<PollAnswer>> GetByPollIdAsync(int pollId);
		Task<ServiceResponse<PollAnswer>> AddAnswerAsync(AddPollAnswerRequest request);
	}
}