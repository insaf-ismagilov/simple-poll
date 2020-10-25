namespace SimplePoll.Infrastructure.DataAccess
{
	public static class DbParameterHelper
	{
		public static DbParameter Create(string name, object value) => new DbParameter(name, value);
	}
}