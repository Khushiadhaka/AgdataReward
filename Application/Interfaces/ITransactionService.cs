using Domain.Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // Transaction service interface defining operations for points transactions
    public interface ITransactionService
    {
        RewardTransaction RecordTransaction(Guid userId, int pointsChange, string notes, Guid? eventId = null, Guid? redemptionId = null);
        // Record a points transaction

        IEnumerable<RewardTransaction> GetUserTransactions(Guid userId);
        // Get all transactions of a user
    }
}
