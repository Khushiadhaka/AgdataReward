using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Infrastructure.Repository
{
    // In-memory repository for UserAccount entity
    public class InMemoryUserAccountRepository : IUserAccountRepository
    {
        private readonly List<UserAccount> _accounts = new List<UserAccount>(); // Internal memory store

        // Add new user account
        public Task AddAsync(UserAccount account)
        {
            _accounts.Add(account);
            return Task.CompletedTask;
        }

        // Get account by User ID
        public Task<UserAccount> GetByUserIdAsync(Guid userId)
        {
            var account = _accounts.FirstOrDefault(a => a.UserId == userId);
            return Task.FromResult(account);
        }

        // Get all accounts
        public Task<IEnumerable<UserAccount>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<UserAccount>>(_accounts);
        }

        // Update existing account
        public Task UpdateAsync(UserAccount account)
        {
            var existing = _accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (existing != null)
            {
                _accounts.Remove(existing);
                _accounts.Add(account);
            }
            return Task.CompletedTask;
        }

        // Delete account by User ID
        public Task DeleteAsync(Guid userId)
        {
            var account = _accounts.FirstOrDefault(a => a.UserId == userId);
            if (account != null)
                _accounts.Remove(account);

            return Task.CompletedTask;
        }
    }
}

