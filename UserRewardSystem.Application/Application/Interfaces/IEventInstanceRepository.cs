using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    public interface IEventInstanceRepository
    {
        Task AddAsync(EventInstance instance);
        Task<EventInstance> GetByIdAsync(Guid id);
        Task<IEnumerable<EventInstance>> GetAllAsync();
        Task UpdateAsync(EventInstance instance);
    }
}
