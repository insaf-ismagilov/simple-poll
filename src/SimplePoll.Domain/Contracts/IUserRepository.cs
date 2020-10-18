﻿using System.Threading.Tasks;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Domain.Contracts
{
	public interface IUserRepository
	{
		Task<User> GetAsync(int id);
		Task<int> AddAsync(User user);
		Task<int?> UpdateAsync(User user);
	}
}