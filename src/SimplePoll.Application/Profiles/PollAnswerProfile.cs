using AutoMapper;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Application.Profiles
{
	public class PollAnswerProfile : Profile
	{
		public PollAnswerProfile()
		{
			CreateMap<AddPollAnswerRequest, PollAnswer>()
				.ForMember(m => m.Id, o => o.Ignore());
		}
	}
}