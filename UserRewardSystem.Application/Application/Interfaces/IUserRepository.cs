using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Application.Interfaces
{
    // Defines contract for User data operations
    public interface IUserRepository
    {
        Task AddAsync(User user);                        // Add new user
        Task<User> GetByIdAsync(Guid id);               // Get user by ID
        Task<User> GetByEmailAsync(string email);       // Get user by email
        Task<IEnumerable<User>> GetAllAsync();           // Get all users
        Task UpdateAsync(User user);                     // Update user details
        Task DeleteAsync(Guid id);                       // Delete user
    }
}
