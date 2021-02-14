﻿namespace SimplePoll.Domain.Entities
{
	public class PollOption : BaseEntity<int>
	{
		public string Text { get; set; }
		public string Value { get; set; }
		public int PollId { get; set; }
	}
}