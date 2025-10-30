using Domain.Domain.Common;
using System;

namespace Domain.Domain.Entities.Event
{
    // Represents a scheduled event
    public class Event : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; } // Definition reference
        public DateTime ScheduledDate { get; private set; } // Scheduled time
        public bool IsActive { get; private set; }          // Active status

        public Event(Guid eventDefinitionId, DateTime scheduledDate)
        {
            if (eventDefinitionId == Guid.Empty)
                throw new ValidationException("Invalid event definition ID");

            EventDefinitionId = eventDefinitionId;
            ScheduledDate = scheduledDate;
            IsActive = true;
        }

        // Deactivate event
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }
        // Reschedule event
        public void Reschedule(DateTime newDate)
        {
            if (newDate < DateTime.UtcNow)
                throw new ValidationException("Cannot reschedule to a past date");
            ScheduledDate = newDate;
            MarkUpdated();
        }
    }
}

