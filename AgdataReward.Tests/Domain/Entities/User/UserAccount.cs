using Domain.Domain.Common;
using System;

namespace Domain.Domain.Entities.User
{
    // Represents a user's reward points account
    public class UserAccount
    {
        public Guid UserId { get; private set; }  // Linked user's ID
        public int Points { get; private set; }   // Current points balance

        // Constructor initializes account for a user
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
            if (points <= 0) throw new ValidationException("Points must be greater than zero");
            Points += points;
        }

        // Redeem (deduct) points
        public void RedeemPoints(int points)
        {
            if (points <= 0) throw new ValidationException("Points must be greater than zero");
            if (Points < points) throw new ValidationException("Insufficient points");
            Points -= points;
        }

        // Update total points directly
        public void UpdatePoints(int points)
        {
            if (points < 0) throw new ValidationException("Points cannot be negative");
            Points = points;
        }
    }
}
