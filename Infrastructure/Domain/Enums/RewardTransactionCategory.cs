namespace agdata.Domain.Enums
{
    // Describes the kind of transaction performed
    public enum RewardTransactionCategory
    {
        Earned,     // Points added to balance
        Redeemed,   // Points spent
        Bonus,      // Extra reward or adjustment
        Refund      // Returned or reversed transaction
    }
}

