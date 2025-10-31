using System;

namespace UserRewardSystem.Domain.Entities.Transaction
{
    // Lightweight summary object for quick views or dashboards
    public class TransactionSummary
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}

