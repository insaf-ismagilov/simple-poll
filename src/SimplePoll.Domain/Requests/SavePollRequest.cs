using System.Collections.Generic;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Domain.Requests
{
	public class CreatePollRequest : SavePollRequest
	{
		public ICollection<SavePollOptionRequest> Options { get; set; }
	}

	public class UpdatePollRequest : SavePollRequest
	{
		public int Id { get; set; }
		public ICollection<UpdatePollOptionRequest> Options { get; set; }
	}

	public abstract class SavePollRequest
	{
		public string Title { get; set; }
		public PollStatus Status { get; set; }
	}

	public class SavePollOptionRequest
	{
		public string Text { get; set; }
		public string Value { get; set; }
	}

	public class UpdatePollOptionRequest : SavePollOptionRequest
	{
		public int Id { get; set; }
	}
}