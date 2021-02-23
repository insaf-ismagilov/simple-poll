using AutoMapper;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;

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