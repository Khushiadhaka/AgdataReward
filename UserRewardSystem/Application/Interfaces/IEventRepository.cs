using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    // Interface for managing Event entities
    public interface IEventRepository
    {
        Task AddAsync(Event ev);
        Task<Event> GetByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task UpdateAsync(Event ev);
        Task DeleteAsync(Guid id);
    }
}

