namespace SimplePoll.Domain
{
	public abstract class BaseEntity<T>
	{
		public T Id { get; init; }
	}
}