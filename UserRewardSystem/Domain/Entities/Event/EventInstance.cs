using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Represents a specific occurrence or execution of an event
    public class EventInstance : BaseEntity
    {
        public Guid EventId { get; private set; }       // Reference to Event
        public DateTime StartDate { get; private set; } // When the event started
        public DateTime EndDate { get; private set; }   // When the event ended
        public bool IsCompleted { get; private set; }   // Completion status

        // Constructor
        public EventInstance(Guid eventId, DateTime startDate, DateTime endDate)
        {
            if (eventId == Guid.Empty)
                throw new ValidationException("Invalid event ID");
            if (endDate <= startDate)
                throw new ValidationException("End date must be after start date");

            EventId = eventId;
            StartDate = startDate;
            EndDate = endDate;
            IsCompleted = false;
        }

        // Mark event as completed
        public void MarkCompleted()
        {
            IsCompleted = true;
            MarkUpdated();
        }
    }
}
