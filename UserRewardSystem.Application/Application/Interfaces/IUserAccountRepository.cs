using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Application.Interfaces
{
    // Defines contract for UserAccount data operations
    public interface IUserAccountRepository
    {
        Task AddAsync(UserAccount account);              // Add new account
        Task<UserAccount> GetByUserIdAsync(Guid userId); // Get account by user ID
        Task<IEnumerable<UserAccount>> GetAllAsync();    // Get all accounts
        Task UpdateAsync(UserAccount account);           // Update account
        Task DeleteAsync(Guid userId);                   // Delete account
    }
}
