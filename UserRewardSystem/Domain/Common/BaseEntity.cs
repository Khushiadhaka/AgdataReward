using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRewardSystem.Domain.Common
{
    // Base entity for all domain models
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }           // Unique ID
        public DateTime CreatedAt { get; private set; }  // Record created time
        public DateTime? UpdatedAt { get; private set; } // Record updated time

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        protected void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow; // Update timestamp
        }
    }
}
