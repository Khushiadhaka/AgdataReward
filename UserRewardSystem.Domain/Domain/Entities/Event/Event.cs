using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Represents a scheduled occurrence of an event definition
    public class Event : BaseEntity
    {
        public Guid EventDefinitionId { get; private set; }  // Linked event definition ID
        public DateTime ScheduledDate { get; private set; }   // Scheduled date of the event
        public bool IsActive { get; private set; }            // Indicates if the event is active

        // Constructor
        public Event(Guid eventDefinitionId, DateTime scheduledDate)
        {
            if (eventDefinitionId == Guid.Empty)
                throw new ValidationException("Event definition ID cannot be empty");
            if (scheduledDate < DateTime.UtcNow.Date)
                throw new ValidationException("Scheduled date cannot be in the past");

            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;

            EventDefinitionId = eventDefinitionId;
            ScheduledDate = scheduledDate;
            IsActive = true;
        }

        // Reschedule the event
        public void Reschedule(DateTime newDate)
        {
            if (newDate < DateTime.UtcNow.Date)
                throw new ValidationException("New date cannot be in the past");

            ScheduledDate = newDate;
            MarkUpdated();
        }

        // Deactivate event (for cancellation)
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }
    }
}
