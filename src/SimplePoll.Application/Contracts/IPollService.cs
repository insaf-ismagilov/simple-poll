using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application.Contracts
{
	public interface IPollService
	{
		Task<ServiceResponse<Poll>> CreateAsync(CreatePollRequest poll);
		Task<ServiceResponse<Poll>> UpdateAsync(UpdatePollRequest poll);
		Task<Poll> GetByIdAsync(int id);
		Task<ICollection<Poll>> GetAllAsync();
	}
}