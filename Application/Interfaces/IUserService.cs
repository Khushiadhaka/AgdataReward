using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain.Entities.User;
using Domain.Domain.Enums;

namespace Application.Interfaces
{
    // Interface for user-related business logic
    public interface IUserService
    {
        Task<User> RegisterUserAsync(string name, string email, string employeeId, UserRole role); // Register a new user
        Task<User> GetByIdAsync(Guid id);                                                          // Get user by ID
        Task<User> GetByEmailAsync(string email);                                                  // Get user by email
        Task<IEnumerable<User>> GetAllAsync();                                                     // Get all users
        Task UpdateUserAsync(Guid userId, string name, string email, string employeeId, UserRole role); // Update user
        void AddPoints(Guid userId, int points);                                                   // Add reward points
        void RedeemPoints(Guid userId, int points);                                                // Redeem points
        int GetPointsBalance(Guid userId);                                                         // Get current balance
    }
}
