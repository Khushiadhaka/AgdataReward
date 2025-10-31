using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryEventRepository : IEventRepository
    {
        private readonly List<Event> _events = new List<Event>();

        public Task AddAsync(Event ev)
        {
            _events.Add(ev);
            return Task.CompletedTask;
        }

        public Task<Event> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public Task<IEnumerable<Event>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Event>>(_events);
        }

        public Task UpdateAsync(Event ev)
        {
            var existing = _events.FirstOrDefault(e => e.Id == ev.Id);
            if (existing != null)
            {
                _events.Remove(existing);
                _events.Add(ev);
            }
            return Task.CompletedTask;
        }
    }
}
