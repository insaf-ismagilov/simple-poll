using System.Threading.Tasks;
using SimplePoll.Domain.Contracts.Repositories;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Infrastructure.DataAccess.Repositories
{
	public class PollAnswerRepository : IPollAnswerRepository
	{
		private readonly IDatabaseRepository _databaseRepository;

		public PollAnswerRepository(IDatabaseRepository databaseRepository)
		{
			_databaseRepository = databaseRepository;
		}

		public Task<PollAnswer> GetByIdAsync(int id)
		{
			return _databaseRepository.GetAsync<PollAnswer>(Constants.Functions.PollAnswerRepository.GetById,
				DbParameterHelper.Create(nameof(id), id));
		}

		public Task<int> AddAnswerAsync(PollAnswer pollAnswer)
		{
			return _databaseRepository.GetAsync<int>(Constants.Functions.PollAnswerRepository.Add,
				DbParameterHelper.Create(nameof(pollAnswer.PollOptionId), pollAnswer.PollOptionId),
				DbParameterHelper.Create(nameof(pollAnswer.UserId), pollAnswer.UserId));
		}
	}
}