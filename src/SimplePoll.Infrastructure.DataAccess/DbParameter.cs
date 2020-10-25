using System.Linq;

namespace SimplePoll.Infrastructure.DataAccess
{
	public class DbParameter
	{
		private const string Prefix = "p_";

		public string Name { get; }
		public object Value { get; }

		public DbParameter(string name, object value)
		{
			Name = Prefix + ToUnderscoreCase(name);
			Value = value;
		}

		private static string ToUnderscoreCase(string str)
		{
			return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
		}
	}
}