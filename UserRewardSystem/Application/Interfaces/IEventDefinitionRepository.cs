using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    // Interface for EventDefinition repository
    public interface IEventDefinitionRepository
    {
        Task AddAsync(EventDefinition definition);
        Task<EventDefinition> GetByIdAsync(Guid id);
        Task<IEnumerable<EventDefinition>> GetAllAsync();
        Task UpdateAsync(EventDefinition definition);
        Task DeleteAsync(Guid id);
    }
}

