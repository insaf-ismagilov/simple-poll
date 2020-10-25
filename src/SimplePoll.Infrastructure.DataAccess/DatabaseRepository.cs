using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace SimplePoll.Infrastructure.DataAccess
{
	public class DatabaseRepository : IDatabaseRepository
	{
		private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

		public DatabaseRepository(IDatabaseConnectionProvider databaseConnectionProvider)
		{
			_databaseConnectionProvider = databaseConnectionProvider;
		}

		public Task<T> GetAsync<T>(string functionName, params DbParameter[] paramaters)
		{
			using var connection = _databaseConnectionProvider.Create();
			connection.Open();

			return connection.QueryFirstOrDefaultAsync<T>(functionName, GetParameters(paramaters), null, null, CommandType.StoredProcedure);
		}

		public Task<IEnumerable<T>> GetCollectionAsync<T>(string functionName, params DbParameter[] paramaters)
		{
			using var connection = _databaseConnectionProvider.Create();
			connection.Open();
			
			return connection.QueryAsync<T>(functionName, GetParameters(paramaters), null, null, CommandType.StoredProcedure);
		}

		public Task ExecuteAsync(string functionName, params DbParameter[] paramaters)
		{
			using var connection = _databaseConnectionProvider.Create();
			connection.Open();
			
			return connection.ExecuteAsync(functionName, GetParameters(paramaters), null, null, CommandType.StoredProcedure);
		}

		private static object GetParameters(params DbParameter[] parameters)
		{
			var param = new DynamicParameters();

			foreach (var parameter in parameters)
			{
				param.Add(parameter.Name, parameter.Value);
			}

			return param;
		}
	}
}