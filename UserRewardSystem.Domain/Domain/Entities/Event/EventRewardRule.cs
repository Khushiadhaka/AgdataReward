using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    public class EventRewardRule : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; }
        public string Condition { get; private set; }
        public int Points { get; private set; }

        public EventRewardRule(Guid eventDefinitionId, string condition, int points)
        {
            if (string.IsNullOrWhiteSpace(condition))
                throw new ArgumentException("Condition cannot be empty");
            if (points <= 0)
                throw new ArgumentException("Points must be greater than zero");

            EventDefinitionId = eventDefinitionId;
            Condition = condition;
            Points = points;
        }

        // ✅ Correct Update method name
        public void Update(string condition, int points)
        {
            if (string.IsNullOrWhiteSpace(condition))
                throw new ArgumentException("Condition cannot be empty");
            if (points <= 0)
                throw new ArgumentException("Points must be greater than zero");

            Condition = condition;
            Points = points;
            MarkUpdated();
        }
    }
}
