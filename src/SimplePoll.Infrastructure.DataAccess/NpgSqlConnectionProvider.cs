using System.Data;
using Npgsql;

namespace SimplePoll.Infrastructure.DataAccess
{
	public class NpgSqlConnectionProvider : IDatabaseConnectionProvider
	{
		public string ConnectionString { get; }

		public NpgSqlConnectionProvider(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public IDbConnection Create()
		{
			Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
			return new NpgsqlConnection(ConnectionString);
		}
	}
}