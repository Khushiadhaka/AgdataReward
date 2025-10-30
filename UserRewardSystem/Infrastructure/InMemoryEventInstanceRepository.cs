using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryEventInstanceRepository : IEventInstanceRepository
    {
        private readonly List<EventInstance> _instances = new List<EventInstance>();

        public Task AddAsync(EventInstance instance)
        {
            _instances.Add(instance);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var inst = _instances.FirstOrDefault(i => i.Id == id);
            if (inst != null) _instances.Remove(inst);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<EventInstance>> GetAllAsync() =>
            Task.FromResult<IEnumerable<EventInstance>>(_instances);

        public Task<EventInstance> GetByIdAsync(Guid id) =>
            Task.FromResult(_instances.FirstOrDefault(i => i.Id == id));

        public Task UpdateAsync(EventInstance instance)
        {
            var existing = _instances.FirstOrDefault(i => i.Id == instance.Id);
            if (existing != null)
            {
                _instances.Remove(existing);
                _instances.Add(instance);
            }
            return Task.CompletedTask;
        }
    }
}

