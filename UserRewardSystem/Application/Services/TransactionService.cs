using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces.Transactions;
using UserRewardSystem.Application.Interfaces.Repositories;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Entities.Transaction;
using UserRewardSystem.Domain.Enums;


namespace UserRewardSystem.Application.Services.Transactions
{
    // Business logic layer for managing transactions
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        // Create a new transaction
        public async Task<Transaction> CreateAsync(Guid userId, Guid productId, decimal amount, int rewardPoints, TransactionType type)
        {
            var transaction = new Transaction(userId, productId, amount, rewardPoints, type);
            await _repository.AddAsync(transaction);
            return transaction;
        }

        // Get transaction by ID
        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Get all transactions for a specific user
        public async Task<IEnumerable<Transaction>> GetAllByUserIdAsync(Guid userId)
        {
            return await _repository.GetAllByUserIdAsync(userId);
        }

        // Update an existing transaction
        public async Task UpdateAsync(Guid id, decimal amount, int rewardPoints, TransactionType type)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction == null)
                throw new ValidationException("Transaction not found");

            transaction.Update(amount, rewardPoints, type);
            await _repository.UpdateAsync(transaction);
        }

        // Delete a transaction
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

