using Domain.Domain.Common;
using System;

namespace Domain.Domain.Entities.Event
{
    // Defines the reward criteria for an event
    public class EventRewardRule : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; }
        public string Condition { get; private set; }
        public int RewardPoints { get; private set; }

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
