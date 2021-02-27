using System.Collections.Generic;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Application.Models.Responses.Polls
{
	public class PollPreview
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public PollStatus Status { get; set; }
		public PollType Type { get; set; }
		
		public ICollection<PollPreviewOption> Options { get; set; }
	}
}