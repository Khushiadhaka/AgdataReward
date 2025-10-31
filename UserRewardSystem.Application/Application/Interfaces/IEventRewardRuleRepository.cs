using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    public interface IEventRewardRuleRepository
    {
        Task AddAsync(EventRewardRule rule);
        Task<EventRewardRule> GetByIdAsync(Guid id);
        Task<IEnumerable<EventRewardRule>> GetAllAsync();
        Task UpdateAsync(EventRewardRule rule);
    }
}
