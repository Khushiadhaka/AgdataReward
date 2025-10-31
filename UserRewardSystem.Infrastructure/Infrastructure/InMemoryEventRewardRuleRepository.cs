using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryEventRewardRuleRepository : IEventRewardRuleRepository
    {
        private readonly List<EventRewardRule> _rules = new List<EventRewardRule>();

        public Task AddAsync(EventRewardRule rule)
        {
            _rules.Add(rule);
            return Task.CompletedTask;
        }

        public Task<EventRewardRule> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_rules.FirstOrDefault(r => r.Id == id));
        }

        public Task<IEnumerable<EventRewardRule>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<EventRewardRule>>(_rules);
        }

        public Task UpdateAsync(EventRewardRule rule)
        {
            var existing = _rules.FirstOrDefault(r => r.Id == rule.Id);
            if (existing != null)
            {
                _rules.Remove(existing);
                _rules.Add(rule);
            }
            return Task.CompletedTask;
        }
    }
}
