using System.Collections.Generic;
using SimplePoll.Domain.Enums;

namespace SimplePoll.Domain.Entities
{
	public class Poll : BaseEntity<int>
	{
		public string Title { get; set; }
		public PollStatus Status { get; set; }
		public ICollection<PollOption> Options { get; set; }
	}
}