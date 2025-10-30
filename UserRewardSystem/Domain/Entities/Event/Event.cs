using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Represents a scheduled instance of an event definition
    public class Event : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; }  // Reference to EventDefinition
        public DateTime ScheduledDate { get; private set; }  // When this event is scheduled
        public bool IsActive { get; private set; }           // Whether the event is active

        // Constructor
        public Event(Guid eventDefinitionId, DateTime scheduledDate)
        {
            if (eventDefinitionId == Guid.Empty)
                throw new ValidationException("Invalid event definition ID");

            EventDefinitionId = eventDefinitionId;
            ScheduledDate = scheduledDate;
            IsActive = true;
        }

        // Deactivate the event
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }

        // Reschedule event to a new date
        public void Reschedule(DateTime newDate)
        {
            if (newDate < DateTime.UtcNow)
                throw new ValidationException("Cannot reschedule to a past date");

            ScheduledDate = newDate;
            MarkUpdated();
        }
    }
}

