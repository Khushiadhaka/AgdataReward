using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain.Entities.User;
using Application.Interfaces; 

namespace Infrastructure.Repositories
{
    // Concrete in-memory repository for user accounts
    public class InMemoryUserAccountRepository : IUserAccountRepository
    {
        private readonly List<UserAccount> _accounts = new List<UserAccount>();

        public void Add(UserAccount account)
        {
            _accounts.Add(account);
        }

        public UserAccount GetByUserId(Guid userId)
        {
            var account = _accounts.FirstOrDefault(a => a.UserId == userId);
            if (account == null)
                throw new InvalidOperationException("Account not found");
            return account;
        }

        public void Update(UserAccount account)
        {
            var existing = _accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (existing != null)
            {
                _accounts.Remove(existing);
                _accounts.Add(account);
            }
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _accounts;
        }
    }
}
