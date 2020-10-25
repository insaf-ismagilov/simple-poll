using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePoll.Infrastructure.DataAccess
{
	public interface IDatabaseRepository
	{
		Task<T> GetAsync<T>(string functionName, params DbParameter[] paramaters);
		Task<IEnumerable<T>> GetCollectionAsync<T>(string functionName, params DbParameter[] paramaters);
		Task ExecuteAsync(string functionName, params DbParameter[] paramaters);
	}
}