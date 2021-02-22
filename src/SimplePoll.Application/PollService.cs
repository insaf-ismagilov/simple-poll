using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimplePoll.Domain.Contracts.Repositories;
using SimplePoll.Domain.Contracts.Services;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application
{
	public class PollService : IPollService
	{
		private readonly IMapper _mapper;
		private readonly IPollRepository _pollRepository;

		public PollService(
			IMapper mapper,
			IPollRepository pollRepository)
		{
			_mapper = mapper;
			_pollRepository = pollRepository;
		}
		
		public async Task<ServiceResponse<Poll>> CreateAsync(CreatePollRequest request)
		{
			var pollToCreate = _mapper.Map<Poll>(request);
			
			var newId = await _pollRepository.CreateAsync(pollToCreate);
			var newPoll = await GetByIdAsync(newId);

			return ServiceResponse<Poll>.Success(newPoll);
		}

		public async Task<ServiceResponse<Poll>> UpdateAsync(UpdatePollRequest request)
		{
			var pollToUpdate = _mapper.Map<Poll>(request);
			
			var updatedId = await _pollRepository.UpdateAsync(pollToUpdate);
			var updatedPoll = updatedId.HasValue ? await GetByIdAsync(updatedId.Value) : null;
			
			return ServiceResponse<Poll>.Success(updatedPoll);
		}

		public Task<Poll> GetByIdAsync(int id)
		{
			return _pollRepository.GetByIdAsync(id);
		}

		public Task<ICollection<Poll>> GetAllAsync()
		{
			return _pollRepository.GetAllAsync();
		}
	}
}