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

        public Task DeleteAsync(Guid id)
        {
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule != null) _rules.Remove(rule);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<EventRewardRule>> GetAllAsync() =>
            Task.FromResult<IEnumerable<EventRewardRule>>(_rules);

        public Task<EventRewardRule> GetByIdAsync(Guid id) =>
            Task.FromResult(_rules.FirstOrDefault(r => r.Id == id));

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

