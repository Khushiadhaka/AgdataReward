using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;

using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Infrastructure.Repository
{
    // In-memory implementation for User repository
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>(); // Internal data storage

        // Adds new user
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        // Gets user by ID
        public Task<User> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        // Gets user by email
        public Task<User> GetByEmailAsync(string email)
        {
            return Task.FromResult(_users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
        }

        // Gets all users
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users.ToList());
        }

        // Updates existing user
        public Task UpdateAsync(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                _users.Remove(existing);
                _users.Add(user);
            }
            return Task.CompletedTask;
        }

        // Deletes user by ID
        public Task DeleteAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
