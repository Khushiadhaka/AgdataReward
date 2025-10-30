using Domain.Domain.Common;

namespace Domain.Domain.Entities.Event
{
    // Defines type of event (e.g., “Sales Campaign”)
    public class EventDefinition : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int RewardPoints { get; private set; }

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

