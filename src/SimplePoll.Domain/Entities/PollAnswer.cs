namespace SimplePoll.Domain.Entities
{
	public class PollAnswer : BaseEntity<int>
	{
		public int PollId { get; set; }
		public int PollOptionId { get; set; }
		public int UserId { get; set; }
	}
}