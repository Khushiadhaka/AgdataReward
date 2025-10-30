using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Defines a reusable type of event (e.g., “Sales Campaign” or “Employee Achievement”)
    public class EventDefinition : BaseEntity
    {
        public string Name { get; private set; }          // Event name
        public string Description { get; private set; }   // Event description
        public int RewardPoints { get; private set; }     // Reward points associated with the event

        // Constructor
        public EventDefinition(string name, string description, int rewardPoints)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Name cannot be empty");
            if (rewardPoints <= 0)
                throw new ValidationException("Reward points must be positive");

            Name = name;
            Description = description;
            RewardPoints = rewardPoints;
        }

        // Update definition details
        public void Update(string name, string description, int rewardPoints)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Name cannot be empty");
            if (rewardPoints <= 0)
                throw new ValidationException("Reward points must be positive");

            Name = name;
            Description = description;
            RewardPoints = rewardPoints;
            MarkUpdated();
        }
    }
}
