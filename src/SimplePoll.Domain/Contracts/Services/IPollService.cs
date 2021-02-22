using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Domain.Contracts.Services
{
	public interface IPollService
	{
		Task<ServiceResponse<Poll>> CreateAsync(CreatePollRequest poll);
		Task<ServiceResponse<Poll>> UpdateAsync(UpdatePollRequest poll);
		Task<Poll> GetByIdAsync(int id);
		Task<ICollection<Poll>> GetAllAsync();
	}
}