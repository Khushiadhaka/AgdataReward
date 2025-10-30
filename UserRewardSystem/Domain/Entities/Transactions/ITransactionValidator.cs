namespace UserRewardSystem.Domain.Entities.Transaction
{
    // Contract for validating transaction business rules
    public interface ITransactionValidator
    {
        void ValidateAmount(decimal amount);
        void ValidateRewardPoints(int points);
    }
}

