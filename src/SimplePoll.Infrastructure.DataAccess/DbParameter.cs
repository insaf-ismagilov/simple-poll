namespace SimplePoll.Infrastructure.DataAccess
{
	public class DbParameter
	{
		private const string Prefix = "p_";

		public string Name { get; }
		public object Value { get; }

		public DbParameter(string name, object value)
		{
			Name = Prefix + name.ToLower();
			Value = value;
		}
	}
}