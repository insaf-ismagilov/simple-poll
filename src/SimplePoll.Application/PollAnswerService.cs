using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimplePoll.Application.Contracts;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Enums;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application
{
	public class PollAnswerService : IPollAnswerService
	{
		private readonly IMapper _mapper;
		private readonly IPollAnswerRepository _pollAnswerRepository;
		private readonly IPollService _pollService;

		public PollAnswerService(
			IMapper mapper,
			IPollAnswerRepository pollAnswerRepository,
			IPollService pollService)
		{
			_mapper = mapper;
			_pollAnswerRepository = pollAnswerRepository;
			_pollService = pollService;
		}

		public Task<PollAnswer> GetByIdAsync(int id)
		{
			return _pollAnswerRepository.GetByIdAsync(id);
		}

		public Task<ICollection<PollAnswer>> GetByPollIdAsync(int pollId)
		{
			return _pollAnswerRepository.GetByPollIdAsync(pollId);
		}

		public async Task<ServiceResponse<PollAnswer>> AddAnswerAsync(AddPollAnswerRequest request)
		{
			var pollAnswerToAdd = _mapper.Map<PollAnswer>(request);

			var existingPoll = await _pollService.GetByIdAsync(request.PollId);

			if (existingPoll == null)
				return ServiceResponse<PollAnswer>.Error($"Poll <{pollAnswerToAdd.PollId}> not found.");

			if (existingPoll.Status != PollStatus.Active)
				return ServiceResponse<PollAnswer>.Error($"Poll <{pollAnswerToAdd.PollId}> is not active.");

			if (existingPoll.Options.All(x => x.Id != pollAnswerToAdd.PollOptionId))
				return ServiceResponse<PollAnswer>.Error($"Poll <{pollAnswerToAdd.PollId}> does not contain option <{pollAnswerToAdd.PollOptionId}>");

			var pollAnswers = await GetByPollIdAsync(existingPoll.Id);
			if (pollAnswers.Any(x => x.UserId == pollAnswerToAdd.UserId))
				return ServiceResponse<PollAnswer>.Error($"User <{pollAnswerToAdd.UserId}> has already answered the Poll <{pollAnswerToAdd.PollId}>.");

			var newId = await _pollAnswerRepository.AddAnswerAsync(pollAnswerToAdd);

			var pollAnswer = await GetByIdAsync(newId);

			return ServiceResponse<PollAnswer>.Success(pollAnswer);
		}
	}
}