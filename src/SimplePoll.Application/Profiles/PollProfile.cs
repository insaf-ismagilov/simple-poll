using AutoMapper;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Application.Profiles
{
	public class PollProfile : Profile
	{
		public PollProfile()
		{
			CreateMap<CreatePollRequest, Poll>()
				.ForMember(m => m.Id, o => o.Ignore());

			CreateMap<UpdatePollRequest, Poll>();

			CreateMap<SavePollOptionRequest, PollOption>()
				.ForMember(m => m.Id, o => o.Ignore());
		}
	}
}