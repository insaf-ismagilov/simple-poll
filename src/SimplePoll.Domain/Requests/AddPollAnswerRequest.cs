namespace SimplePoll.Domain.Requests
{
	public class AddPollAnswerRequest
	{
		public int UserId { get; set; }
		public int PollId { get; set; }
		public int PollOptionId { get; set; }
	}
}