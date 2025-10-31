using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;
using UserRewardSystem.Application.Interfaces;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryEventDefinitionRepository : IEventDefinitionRepository
    {
        private readonly List<EventDefinition> _definitions = new List<EventDefinition>();

        public Task AddAsync(EventDefinition def)
        {
            _definitions.Add(def);
            return Task.CompletedTask;
        }

        public Task<EventDefinition> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_definitions.FirstOrDefault(d => d.Id == id));
        }

        public Task<IEnumerable<EventDefinition>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<EventDefinition>>(_definitions);
        }

        public Task UpdateAsync(EventDefinition def)
        {
            var existing = _definitions.FirstOrDefault(d => d.Id == def.Id);
            if (existing != null)
            {
                _definitions.Remove(existing);
                _definitions.Add(def);
            }
            return Task.CompletedTask;
        }
    }
}
