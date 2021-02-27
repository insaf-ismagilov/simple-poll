using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Infrastructure.DataAccess.Constants;
using SimplePoll.Infrastructure.DataAccess.Data;

namespace SimplePoll.Infrastructure.DataAccess.Repositories
{
	public class PollRepository : IPollRepository
	{
		private readonly IDatabaseRepository _databaseRepository;

		public PollRepository(IDatabaseRepository databaseRepository)
		{
			_databaseRepository = databaseRepository;
		}

		public Task<int> CreateAsync(Poll poll)
		{
			return _databaseRepository.GetAsync<int>(Functions.PollRepository.Create,
				DbParameterHelper.Create(nameof(poll.Title), poll.Title),
				DbParameterHelper.Create(nameof(poll.Status), poll.Status),
				DbParameterHelper.Create(nameof(poll.Type), poll.Type),
				DbParameterHelper.CreateJsonb(nameof(poll.Options), poll.Options));
		}

		public Task<int?> UpdateAsync(Poll poll)
		{
			return _databaseRepository.GetAsync<int?>(Functions.PollRepository.Update,
				DbParameterHelper.Create(nameof(poll.Id), poll.Id),
				DbParameterHelper.Create(nameof(poll.Title), poll.Title),
				DbParameterHelper.Create(nameof(poll.Status), poll.Status),
				DbParameterHelper.Create(nameof(poll.Type), poll.Type),
				DbParameterHelper.CreateJsonb(nameof(poll.Options), poll.Options));
		}

		public async Task<Poll> GetByIdAsync(int id)
		{
			var records = await _databaseRepository.GetCollectionAsync<PollRecord>(Functions.PollRepository.GetById,
				DbParameterHelper.Create(nameof(id), id));

			return ToPoll(records).FirstOrDefault();
		}

		public async Task<ICollection<Poll>> GetAllAsync()
		{
			var records = await _databaseRepository.GetCollectionAsync<PollRecord>(Functions.PollRepository.GetAll);

			return ToPoll(records).ToList();
		}

		private static IEnumerable<Poll> ToPoll(IEnumerable<PollRecord> pollRecords)
		{
			var polls = new Dictionary<int, Poll>();

			foreach (var pollRecord in pollRecords)
			{
				if (!polls.TryGetValue(pollRecord.Id, out var poll))
				{
					poll = new Poll
					{
						Id = pollRecord.Id,
						Title = pollRecord.Title,
						Status = pollRecord.Status,
						Type = pollRecord.Type,
						Options = new List<PollOption>()
					};

					polls[pollRecord.Id] = poll;
				}

				if (pollRecord.PollOptionId.HasValue)
					poll.Options.Add(new PollOption
					{
						Id = pollRecord.PollOptionId.Value,
						Text = pollRecord.PollOptionText,
						Value = pollRecord.PollOptionValue,
						PollId = pollRecord.PollOptionPollId.GetValueOrDefault()
					});
			}

			return polls.Values;
		}
	}
}