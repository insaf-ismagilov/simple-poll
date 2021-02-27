using System.Collections.Generic;

namespace SimplePoll.Application.Models.Responses.Polls
{
	public class PollPreviewOption
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string Value { get; set; }
		public int TotalAnswers { get; set; }
		public decimal AnswersPercent { get; set; }
		public ICollection<PollPreviewAnswer> Answers { get; set; }
	}
}