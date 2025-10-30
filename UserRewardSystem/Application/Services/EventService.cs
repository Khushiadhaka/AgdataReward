using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Services
{
    // Provides business logic for event operations
    public class EventService
    {
        private readonly IEventRepository _eventRepo;
        private readonly IEventDefinitionRepository _definitionRepo;
        private readonly IEventInstanceRepository _instanceRepo;
        private readonly IEventRewardRuleRepository _rewardRepo;

        public EventService(
            IEventRepository eventRepo,
            IEventDefinitionRepository definitionRepo,
            IEventInstanceRepository instanceRepo,
            IEventRewardRuleRepository rewardRepo)
        {
            _eventRepo = eventRepo;
            _definitionRepo = definitionRepo;
            _instanceRepo = instanceRepo;
            _rewardRepo = rewardRepo;
        }

        // Create a new event definition
        public async Task<EventDefinition> CreateEventDefinitionAsync(string name, string description, int rewardPoints)
        {
            var definition = new EventDefinition(name, description, rewardPoints);
            await _definitionRepo.AddAsync(definition);
            return definition;
        }

        // Schedule a new event based on an existing definition
        public async Task<Event> ScheduleEventAsync(Guid definitionId, DateTime scheduledDate)
        {
            var ev = new Event(definitionId, scheduledDate);
            await _eventRepo.AddAsync(ev);
            return ev;
        }

        // Reschedule an existing event
        public async Task RescheduleEventAsync(Guid eventId, DateTime newDate)
        {
            var ev = await _eventRepo.GetByIdAsync(eventId);
            if (ev == null) throw new Exception("Event not found");

            ev.Reschedule(newDate);
            await _eventRepo.UpdateAsync(ev);
        }

        // Create an event instance (actual occurrence)
        public async Task<EventInstance> CreateEventInstanceAsync(Guid eventId, DateTime start, DateTime end)
        {
            var instance = new EventInstance(eventId, start, end);
            await _instanceRepo.AddAsync(instance);
            return instance;
        }

        // Mark event instance as completed
        public async Task CompleteEventInstanceAsync(Guid instanceId)
        {
            var instance = await _instanceRepo.GetByIdAsync(instanceId);
            if (instance == null) throw new Exception("Event instance not found");

            instance.MarkCompleted();
            await _instanceRepo.UpdateAsync(instance);
        }
    }
}

