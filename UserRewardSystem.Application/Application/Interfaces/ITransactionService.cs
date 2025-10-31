using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Transaction;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Application.Interfaces.Transactions
{
    public interface ITransactionService
    {
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetAllByUserIdAsync(Guid userId);
        Task<Transaction> CreateAsync(Guid userId, Guid productId, decimal amount, int rewardPoints, TransactionType type);
        Task UpdateAsync(Guid id, decimal amount, int rewardPoints, TransactionType type);
        Task<bool> DeleteAsync(Guid id);
    }
}
