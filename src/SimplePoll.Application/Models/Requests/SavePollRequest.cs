using System.Collections.Generic;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Application.Models.Requests
{
	public class CreatePollRequest : SavePollRequest
	{
		public ICollection<CreatePollOptionRequest> Options { get; set; }
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
		public PollType Type { get; set; }
	}

	public class SavePollOptionRequest
	{
		public string Text { get; set; }
		public string Value { get; set; }
	}

	public class CreatePollOptionRequest : SavePollOptionRequest
	{
	}

	public class UpdatePollOptionRequest : SavePollOptionRequest
	{
		public int Id { get; set; }
	}
}