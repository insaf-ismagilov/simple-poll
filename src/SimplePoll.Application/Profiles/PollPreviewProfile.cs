using AutoMapper;
using SimplePoll.Application.Models.Responses.Polls;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Application.Profiles
{
	public class PollPreviewProfile : Profile
	{
		public PollPreviewProfile()
		{
			CreateMap<Poll, PollPreview>();

			CreateMap<PollOption, PollPreviewOption>()
				.ForMember(m => m.TotalAnswers, o => o.Ignore())
				.ForMember(m => m.AnswersPercent, o => o.Ignore())
				.ForMember(m => m.Answers, o => o.Ignore());

			CreateMap<PollAnswer, PollPreviewAnswer>();
		}
	}
}