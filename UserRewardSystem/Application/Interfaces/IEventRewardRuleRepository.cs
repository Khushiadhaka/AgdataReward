using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    // Interface for managing event reward rules
    public interface IEventRewardRuleRepository
    {
        Task AddAsync(EventRewardRule rule);
        Task<EventRewardRule> GetByIdAsync(Guid id);
        Task<IEnumerable<EventRewardRule>> GetAllAsync();
        Task UpdateAsync(EventRewardRule rule);
        Task DeleteAsync(Guid id);
    }
}

