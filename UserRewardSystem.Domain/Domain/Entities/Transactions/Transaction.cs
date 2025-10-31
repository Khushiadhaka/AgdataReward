using System;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Domain.Entities.Transaction
{
    // Represents a financial or reward-related transaction
    public sealed class Transaction : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Amount { get; private set; }
        public int RewardPointsEarned { get; private set; }
        public DateTime Date { get; private set; }
        public TransactionType Type { get; private set; }
        public TransactionStatus Status { get; private set; }

        public Transaction(Guid userId, Guid productId, decimal amount, int rewardPoints, TransactionType type)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("User ID cannot be empty");
            if (productId == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty");
            if (amount <= 0)
                throw new ValidationException("Amount must be positive");
            if (rewardPoints < 0)
                throw new ValidationException("Reward points cannot be negative");

            UserId = userId;
            ProductId = productId;
            Amount = amount;
            RewardPointsEarned = rewardPoints;
            Type = type;
            Date = DateTime.UtcNow;
            Status = TransactionStatus.Pending;
        }

        public void MarkCompleted()
        {
            Status = TransactionStatus.Completed;
            MarkUpdated();
        }

        public void MarkFailed()
        {
            Status = TransactionStatus.Failed;
            MarkUpdated();
        }

        public void Update(decimal amount, int rewardPoints, TransactionType type)
        {
            if (amount <= 0)
                throw new ValidationException("Amount must be positive");
            if (rewardPoints < 0)
                throw new ValidationException("Reward points cannot be negative");

            Amount = amount;
            RewardPointsEarned = rewardPoints;
            Type = type;
            MarkUpdated();
        }
    }
}
