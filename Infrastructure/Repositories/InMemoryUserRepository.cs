using Application.Interfaces;               // For IUserRepository interface
using Domain.Domain.Entities.User;          // For User entity
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    // In-memory implementation of IUserRepository
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();  // In-memory storage for users


        // Add a new user to the list
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;               // No async work, so return completed task
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
            var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }

        // Get all users
        public Task<IEnumerable<User>> ListAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        // Update an existing user
        public Task UpdateAsync(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                _users.Remove(existing);              // Remove old record
                _users.Add(user);                     // Add updated record
            }
            return Task.CompletedTask;
        }

        // Delete a user by ID
        public Task DeleteAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
