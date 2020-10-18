using System;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Domain.Entities
{
	public class UserRole : BaseEntity<UserRoleId>
	{
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime LastModifiedDate { get; set; }
	}
}