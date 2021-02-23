namespace SimplePoll.Infrastructure.DataAccess
{
	public static class DbParameterHelper
	{
		public static DbParameterInfo Create(string name, object value)
		{
			return new(name, value);
		}

		public static DbParameterInfo CreateJsonb(string name, object value)
		{
			return new(name, new JsonbParameter(value));
		}
	}
}