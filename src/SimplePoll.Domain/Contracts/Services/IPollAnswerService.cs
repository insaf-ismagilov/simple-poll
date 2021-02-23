using System.Threading.Tasks;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Domain.Contracts.Services
{
	public interface IPollAnswerService
	{
		Task<PollAnswer> GetByIdAsync(int id);
		Task<ServiceResponse<PollAnswer>> AddAnswerAsync(AddPollAnswerRequest request);
	}
}