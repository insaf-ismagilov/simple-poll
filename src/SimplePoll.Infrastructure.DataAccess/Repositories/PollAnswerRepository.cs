using System.Threading.Tasks;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Infrastructure.DataAccess.Constants;

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
			return _databaseRepository.GetAsync<PollAnswer>(Functions.PollAnswerRepository.GetById,
				DbParameterHelper.Create(nameof(id), id));
		}

		public Task<int> AddAnswerAsync(PollAnswer pollAnswer)
		{
			return _databaseRepository.GetAsync<int>(Functions.PollAnswerRepository.Add,
				DbParameterHelper.Create(nameof(pollAnswer.PollOptionId), pollAnswer.PollOptionId),
				DbParameterHelper.Create(nameof(pollAnswer.UserId), pollAnswer.UserId));
		}
	}
}