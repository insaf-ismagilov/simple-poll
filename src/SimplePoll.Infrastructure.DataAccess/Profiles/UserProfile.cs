using AutoMapper;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Enums;
using SimplePoll.Infrastructure.DataAccess.Data;

namespace SimplePoll.Infrastructure.DataAccess.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserRecord, User>()
				.ForMember(m => m.Role,
					o => o.MapFrom(m => new UserRole
					{
						Id = (UserRoleId) m.RoleId,
						Name = m.RoleName,
						CreatedDate = m.RoleCreatedDate,
						LastModifiedDate = m.RoleLastModifiedDate
					}));
		}
	}
}