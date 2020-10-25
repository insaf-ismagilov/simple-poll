using System.Threading.Tasks;
using AutoMapper;
using SimplePoll.Domain.Contracts;
using SimplePoll.Domain.Entities;
using SimplePoll.Infrastructure.DataAccess.Data;

namespace SimplePoll.Infrastructure.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IMapper _mapper;
		private readonly IDatabaseRepository _databaseRepository;

		public UserRepository(
			IMapper mapper,
			IDatabaseRepository databaseRepository)
		{
			_mapper = mapper;
			_databaseRepository = databaseRepository;
		}
		
		public async Task<User> GetByIdAsync(int id)
		{
			var userRecord = await _databaseRepository.GetAsync<UserRecord>("public.users_getbyid", 
				DbParameterHelper.Create(nameof(id), id));

			return _mapper.Map<User>(userRecord);
		}

		public Task<int> AddAsync(User user)
		{
			throw new System.NotImplementedException();
		}

		public Task<int?> UpdateAsync(User user)
		{
			throw new System.NotImplementedException();
		}
	}
}