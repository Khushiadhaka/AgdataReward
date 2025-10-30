using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain.Entities.User;

namespace Application.Interfaces
{
    // Interface for data access related to Users
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);                        // Add user
        Task<User> GetByIdAsync(Guid id);                      // Get user by ID
        Task<User> GetByEmailAsync(string email);              // Get user by email
        Task<IEnumerable<User>> ListAsync();                   // List all users
        Task UpdateAsync(User user);                           // Update existing user
    }
}
