using System;

namespace Domain.Domain.Common
{
    // Base class for all entities in the domain
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }           // Unique identifier
        public DateTime CreatedAt { get; private set; }  // Record creation time
        public DateTime? UpdatedAt { get; private set; } // Record last updated time

        // Constructor to set creation time
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        // Method to mark the entity as updated
        protected void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}


