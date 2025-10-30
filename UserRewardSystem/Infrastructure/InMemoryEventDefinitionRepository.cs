using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryEventDefinitionRepository : IEventDefinitionRepository
    {
        private readonly List<EventDefinition> _definitions = new List<EventDefinition>();

        public Task AddAsync(EventDefinition definition)
        {
            _definitions.Add(definition);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var def = _definitions.FirstOrDefault(d => d.Id == id);
            if (def != null) _definitions.Remove(def);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<EventDefinition>> GetAllAsync() =>
            Task.FromResult<IEnumerable<EventDefinition>>(_definitions);

        public Task<EventDefinition> GetByIdAsync(Guid id) =>
            Task.FromResult(_definitions.FirstOrDefault(d => d.Id == id));

        public Task UpdateAsync(EventDefinition definition)
        {
            var existing = _definitions.FirstOrDefault(d => d.Id == definition.Id);
            if (existing != null)
            {
                _definitions.Remove(existing);
                _definitions.Add(definition);
            }
            return Task.CompletedTask;
        }
    }
}

