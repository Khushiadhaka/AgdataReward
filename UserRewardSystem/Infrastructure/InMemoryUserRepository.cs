using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Infrastructure.Repository
{
    // In-memory repository for User entity
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>(); // Internal memory store

        // Add a new user
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        // Get user by ID
        public Task<User> GetByIdAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        // Get user by email
        public Task<User> GetByEmailAsync(string email)
        {
            var user = _users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }

        // Get all users
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        // Update existing user
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

        // Delete user by ID
        public Task DeleteAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _users.Remove(user);

            return Task.CompletedTask;
        }
    }
}
