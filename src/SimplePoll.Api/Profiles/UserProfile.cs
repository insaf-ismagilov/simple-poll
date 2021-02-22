using AutoMapper;
using SimplePoll.Api.Models;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Api.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserVm>()
				.ReverseMap()
				.ForMember(m => m.Role, o => o.Ignore())
				.ForMember(m => m.PasswordHash, o => o.Ignore())
				.ForMember(m => m.CreatedDate, o => o.Ignore())
				.ForMember(m => m.LastModifiedDate, o => o.Ignore());
		}
	}
}