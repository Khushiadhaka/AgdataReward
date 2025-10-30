using Domain.Domain.Common;
using System;

namespace Domain.Domain.Entities.Event
{
    // Represents a specific occurrence of an event
    public class EventInstance : BaseEntity
    {
        public Guid EventId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsCompleted { get; private set; }

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

        public void MarkCompleted()
        {
            IsCompleted = true;
            MarkUpdated();
        }
    }
}
