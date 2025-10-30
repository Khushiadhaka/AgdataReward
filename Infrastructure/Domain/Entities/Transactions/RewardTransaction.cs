using Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities.Transactions
{
    // Represents a user's points transaction (earn or redeem)
    public sealed class RewardTransaction
    {
        public Guid TransactionId { get; }
        public Guid UserId { get; }
        public int PointsChange { get; }
        public string Notes { get; }
        public Guid? EventId { get; }
        public Guid? RedemptionId { get; }

        public RewardTransaction(Guid transactionId, Guid userId, int pointsChange, string notes, Guid? eventId = null, Guid? redemptionId = null)
        {
            if (transactionId == Guid.Empty) throw new ValidationException("Transaction ID cannot be empty.");
            if (userId == Guid.Empty) throw new ValidationException("User ID cannot be empty.");
            if (pointsChange == 0) throw new ValidationException("PointsChange cannot be zero.");
            if (string.IsNullOrWhiteSpace(notes)) throw new ValidationException("Notes cannot be empty.");

            TransactionId = transactionId;
            UserId = userId;
            PointsChange = pointsChange;
            Notes = notes;
            EventId = eventId;
            RedemptionId = redemptionId;
        }
    }
