using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.User
{
    // Represents user's reward points account
    public class UserAccount : BaseEntity
    {
        public Guid UserId { get; private set; } // Linked User ID
        public int Points { get; private set; }  // Points balance

        public UserAccount(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("User ID cannot be empty");

            UserId = userId;
            Points = 0;
        }

        // Add reward points
        public void AddPoints(int points)
        {
            if (points <= 0) throw new ValidationException("Points must be positive");
            Points += points;
            MarkUpdated();
        }

        // Redeem reward points
        public void RedeemPoints(int points)
        {
            if (points <= 0) throw new ValidationException("Points must be positive");
            if (Points < points) throw new ValidationException("Insufficient balance");
            Points -= points;
            MarkUpdated();
        }

        // Update total points directly
        public void UpdatePoints(int points)
        {
            if (points < 0) throw new ValidationException("Points cannot be negative");
            Points = points;
            MarkUpdated();
        }
    }
}
