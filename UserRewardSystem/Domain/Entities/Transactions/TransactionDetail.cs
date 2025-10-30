using System;

namespace UserRewardSystem.Domain.Entities.Transaction
{
    // Contains detailed info about a transaction (for reporting)
    public class TransactionDetail
    {
        public Guid TransactionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}

