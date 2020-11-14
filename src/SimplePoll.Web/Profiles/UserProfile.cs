using AutoMapper;
using SimplePoll.Domain.Entities;
using SimplePoll.Web.Models;

namespace SimplePoll.Web.Profiles
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