using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Transaction;

namespace UserRewardSystem.Application.Interfaces.Repositories
{
    // Defines persistence operations for Transaction
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetAllByUserIdAsync(Guid userId);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task<bool> DeleteAsync(Guid id);
    }
}

