using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimplePoll.Application.Contracts;
using SimplePoll.Application.Models.Responses.Polls;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Application
{
	public class PollPreviewService : IPollPreviewService
	{
		private readonly IMapper _mapper;
		private readonly IPollService _pollService;
		private readonly IPollAnswerService _pollAnswerService;

		public PollPreviewService(
			IMapper mapper,
			IPollService pollService,
			IPollAnswerService pollAnswerService)
		{
			_mapper = mapper;
			_pollService = pollService;
			_pollAnswerService = pollAnswerService;
		}

		public async Task<PollPreview> GetByIdAsync(int id)
		{
			var poll = await _pollService.GetByIdAsync(id);
			if (poll == null)
				return null;

			var pollPreview = _mapper.Map<PollPreview>(poll);

			var pollAnswers = await _pollAnswerService.GetByPollIdAsync(id);
			var total = pollAnswers.Count;

			var pollPreviewAnswers = _mapper.Map<ICollection<PollPreviewAnswer>>(pollAnswers);

			var answersByOption = pollPreviewAnswers
				.GroupBy(x => x.PollOptionId)
				.ToDictionary(x => x.Key, x => x.ToList());

			foreach (var option in pollPreview.Options)
			{
				if (!answersByOption.TryGetValue(option.Id, out var answers))
					continue;

				var totalOptionAnswers = answers.Count;
				option.TotalAnswers = totalOptionAnswers;
				option.AnswersPercent = (decimal) totalOptionAnswers / total * 100;

				option.Answers = poll.Type == PollType.Public ? answers : new List<PollPreviewAnswer>();
			}

			return pollPreview;
		}
	}
}