using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Services.Transactions;
using UserRewardSystem.Application.Interfaces.Repositories;
using UserRewardSystem.Domain.Entities.Transaction;
using UserRewardSystem.Domain.Enums;
using Xunit;

namespace UserRewardSystem.Tests
{
    // Simple test class for TransactionService
    public class TransactionServiceTests
    {
        // A very simple in-memory repository for testing
        public class SimpleTransactionRepository : ITransactionRepository
        {
            private readonly List<Transaction> _transactions = new List<Transaction>();

            public Task AddAsync(Transaction transaction)
            {
                _transactions.Add(transaction);
                return Task.CompletedTask;
            }

            public Task<Transaction?> GetByIdAsync(Guid id)
            {
                var transaction = _transactions.Find(t => t.Id == id);
                return Task.FromResult(transaction);
            }

            public Task<IEnumerable<Transaction>> GetAllByUserIdAsync(Guid userId)
            {
                IEnumerable<Transaction> result = _transactions.FindAll(t => t.UserId == userId);
                return Task.FromResult(result);
            }

            public Task UpdateAsync(Transaction transaction)
            {
                // Nothing complex for test purpose
                return Task.CompletedTask;
            }

            public Task<bool> DeleteAsync(Guid id)
            {
                var transaction = _transactions.Find(t => t.Id == id);
                if (transaction != null)
                {
                    _transactions.Remove(transaction);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }

    }
}
