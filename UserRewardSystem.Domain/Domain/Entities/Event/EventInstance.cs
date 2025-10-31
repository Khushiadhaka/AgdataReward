using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Event
{
    // Represents an actual occurrence or execution of a scheduled event
    public class EventInstance : BaseEntity
    {
        public Guid EventId { get; private set; }       // Linked Event ID
        public DateTime StartTime { get; private set; } // Start time of the instance
        public DateTime EndTime { get; private set; }   // End time of the instance
        public bool IsCompleted { get; private set; }   // Completion status

        // Constructor
        public EventInstance(Guid eventId, DateTime startTime, DateTime endTime)
        {
            if (eventId == Guid.Empty)
                throw new ValidationException("Event ID cannot be empty");
            if (endTime <= startTime)
                throw new ValidationException("End time must be after start time");

            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;

            EventId = eventId;
            StartTime = startTime;
            EndTime = endTime;
            IsCompleted = false;
        }

        // Mark this instance as completed
        public void MarkCompleted()
        {
            IsCompleted = true;
            MarkUpdated();
        }

        // Extend event duration
        public void ExtendEndTime(DateTime newEndTime)
        {
            if (newEndTime <= EndTime)
                throw new ValidationException("New end time must be later than the current one");

            EndTime = newEndTime;
            MarkUpdated();
        }
    }
}
