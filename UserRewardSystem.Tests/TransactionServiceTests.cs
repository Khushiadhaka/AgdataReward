using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Services.Transactions;
using UserRewardSystem.Application.Interfaces.Repositories;
using UserRewardSystem.Domain.Entities.Transaction;
using UserRewardSystem.Domain.Enums;
using Xunit;

namespace UserRewardSystem.Tests.Services
{
   
    public class TransactionServiceTests
    {
        //  in-memory repository for testing
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
                // Not needed for simple test
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

        [Fact]
        public async Task CreateTransaction_ShouldWork()
        {
            var repo = new SimpleTransactionRepository();
            var service = new TransactionService(repo);

            var transaction = await service.CreateAsync(
                Guid.NewGuid(),
                Guid.NewGuid(),
                100,
                10,
                TransactionType.Purchase
            );

            Assert.NotNull(transaction);
            Assert.Equal(100, transaction.Amount);
            Assert.Equal(10, transaction.RewardPointsEarned);
        }

        [Fact]
        public async Task DeleteTransaction_ShouldReturnTrue()
        {
            var repo = new SimpleTransactionRepository();
            var service = new TransactionService(repo);

            var t = await service.CreateAsync(Guid.NewGuid(), Guid.NewGuid(), 50, 5, TransactionType.Purchase);

            var result = await service.DeleteAsync(t.Id);

            Assert.True(result);
        }
    }
}

