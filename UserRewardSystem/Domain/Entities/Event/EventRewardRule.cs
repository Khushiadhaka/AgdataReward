using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Defines reward conditions or criteria for an event
    public class EventRewardRule : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; }  // Reference to EventDefinition
        public string Condition { get; private set; }        // Condition for earning reward
        public int RewardPoints { get; private set; }        // Points given when condition met

        // Constructor
        public EventRewardRule(Guid eventDefinitionId, string condition, int rewardPoints)
        {
            if (eventDefinitionId == Guid.Empty)
                throw new ValidationException("Invalid event definition ID");
            if (string.IsNullOrWhiteSpace(condition))
                throw new ValidationException("Condition cannot be empty");
            if (rewardPoints <= 0)
                throw new ValidationException("Reward points must be positive");

            EventDefinitionId = eventDefinitionId;
            Condition = condition;
            RewardPoints = rewardPoints;
        }

        // Update condition and reward points
        public void Update(string condition, int rewardPoints)
        {
            if (string.IsNullOrWhiteSpace(condition))
                throw new ValidationException("Condition cannot be empty");
            if (rewardPoints <= 0)
                throw new ValidationException("Reward points must be positive");

            Condition = condition;
            RewardPoints = rewardPoints;
            MarkUpdated();
        }
    }
}
