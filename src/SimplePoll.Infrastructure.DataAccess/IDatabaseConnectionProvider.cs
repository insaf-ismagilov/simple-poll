using System.Data;

namespace SimplePoll.Infrastructure.DataAccess
{
	public interface IDatabaseConnectionProvider
	{
		string ConnectionString { get; }
		IDbConnection Create();
	}
}