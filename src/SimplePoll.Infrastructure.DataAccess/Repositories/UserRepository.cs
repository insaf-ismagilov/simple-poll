using System.Threading.Tasks;
using AutoMapper;
using SimplePoll.Domain.Contracts.Repositories;
using SimplePoll.Domain.Entities;
using SimplePoll.Infrastructure.DataAccess.Constants;
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
			var userRecord = await _databaseRepository.GetAsync<UserRecord>(Functions.UserRepository.GetById,
				DbParameterHelper.Create(nameof(id), id));

			return _mapper.Map<User>(userRecord);
		}

		public async Task<User> GetByEmailAsync(string email)
		{
			var userRecord = await _databaseRepository.GetAsync<UserRecord>(Functions.UserRepository.GetByEmail,
				DbParameterHelper.Create(nameof(email), email));

			return _mapper.Map<User>(userRecord);
		}

		public Task<int> AddAsync(User user)
		{
			return _databaseRepository.GetAsync<int>(Functions.UserRepository.Add,
				DbParameterHelper.Create(nameof(user.Email), user.Email),
				DbParameterHelper.Create(nameof(user.PasswordHash), user.PasswordHash),
				DbParameterHelper.Create(nameof(user.FirstName), user.FirstName),
				DbParameterHelper.Create(nameof(user.LastName), user.LastName),
				DbParameterHelper.Create("UserRoleId", user.Role.Id));
		}

		public Task<int?> UpdateAsync(User user)
		{
			return _databaseRepository.GetAsync<int?>(Functions.UserRepository.Update,
				DbParameterHelper.Create(nameof(user.Id), user.Id),
				DbParameterHelper.Create(nameof(user.Email), user.Email),
				DbParameterHelper.Create(nameof(user.PasswordHash), user.PasswordHash),
				DbParameterHelper.Create(nameof(user.FirstName), user.FirstName),
				DbParameterHelper.Create(nameof(user.LastName), user.LastName),
				DbParameterHelper.Create("UserRoleId", user.Role.Id));
		}
	}
}