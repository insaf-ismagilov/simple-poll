using SimplePoll.Domain.Entities;

namespace SimplePoll.Infrastructure.Authorization
{
	public interface IJwtGenerator
	{
		string GetToken(User user);
	}
}