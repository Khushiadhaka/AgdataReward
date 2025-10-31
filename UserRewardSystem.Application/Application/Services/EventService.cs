using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventDefinitionRepository _definitionRepository;
        private readonly IEventInstanceRepository _instanceRepository;
        private readonly IEventRewardRuleRepository _ruleRepository;

        public EventService(
            IEventRepository eventRepository,
            IEventDefinitionRepository definitionRepository,
            IEventInstanceRepository instanceRepository,
            IEventRewardRuleRepository ruleRepository)
        {
            _eventRepository = eventRepository;
            _definitionRepository = definitionRepository;
            _instanceRepository = instanceRepository;
            _ruleRepository = ruleRepository;
        }

        // Create a new Event Definition
        public async Task<EventDefinition> CreateEventDefinitionAsync(string name, string description, int rewardPoints)
        {
            var def = new EventDefinition(name, description, rewardPoints);
            await _definitionRepository.AddAsync(def);
            return def;
        }

        // Update existing Event Definition
        public async Task<EventDefinition> UpdateEventDefinitionAsync(Guid definitionId, string name, string description, int rewardPoints)
        {
            var def = await _definitionRepository.GetByIdAsync(definitionId);
            if (def == null)
                throw new Exception("Event definition not found");

            def.Update(name, description, rewardPoints);
            await _definitionRepository.UpdateAsync(def);
            return def;
        }

        // Create / Schedule a new Event from Definition
        public async Task<Event> ScheduleEventAsync(Guid definitionId, DateTime scheduledDate)
        {
            var def = await _definitionRepository.GetByIdAsync(definitionId);
            if (def == null)
                throw new Exception("Event definition not found");

            var ev = new Event(definitionId, scheduledDate);
            await _eventRepository.AddAsync(ev);
            return ev;
        }

        // Reschedule an Event
        public async Task<Event> RescheduleEventAsync(Guid eventId, DateTime newDate)
        {
            var ev = await _eventRepository.GetByIdAsync(eventId);
            if (ev == null)
                throw new Exception("Event not found");

            ev.Reschedule(newDate);
            await _eventRepository.UpdateAsync(ev);
            return ev;
        }

        // Create a new Event Instance (actual occurrence)
        public async Task<EventInstance> CreateEventInstanceAsync(Guid eventId, DateTime startTime, DateTime endTime)
        {
            var ev = await _eventRepository.GetByIdAsync(eventId);
            if (ev == null)
                throw new Exception("Event not found");

            var instance = new EventInstance(eventId, startTime, endTime);
            await _instanceRepository.AddAsync(instance);
            return instance;
        }

        // Mark an Event Instance as completed
        public async Task<EventInstance> CompleteEventInstanceAsync(Guid instanceId)
        {
            var instance = await _instanceRepository.GetByIdAsync(instanceId);
            if (instance == null)
                throw new Exception("Event instance not found");

            instance.MarkCompleted();
            await _instanceRepository.UpdateAsync(instance);
            return instance;
        }

        // Get all Event Definitions
        public Task<IEnumerable<EventDefinition>> GetAllEventDefinitionsAsync() => _definitionRepository.GetAllAsync();

        // Get all Events
        public Task<IEnumerable<Event>> GetAllEventsAsync() => _eventRepository.GetAllAsync();

        // Get all Event Instances
        public Task<IEnumerable<EventInstance>> GetAllEventInstancesAsync() => _instanceRepository.GetAllAsync();

        // Get by Ids
        public Task<EventDefinition> GetEventDefinitionByIdAsync(Guid id) => _definitionRepository.GetByIdAsync(id);
        public Task<Event> GetEventByIdAsync(Guid id) => _eventRepository.GetByIdAsync(id);
        public Task<EventInstance> GetEventInstanceByIdAsync(Guid id) => _instanceRepository.GetByIdAsync(id);

        // Create Reward Rule
        public async Task<EventRewardRule> CreateRewardRuleAsync(Guid definitionId, string condition, int points)
        {
            var def = await _definitionRepository.GetByIdAsync(definitionId);
            if (def == null)
                throw new Exception("Event definition not found");

            var rule = new EventRewardRule(definitionId, condition, points);
            await _ruleRepository.AddAsync(rule);
            return rule;
        }

        // Update Reward Rule
        public async Task<EventRewardRule> UpdateRewardRuleAsync(Guid ruleId, string condition, int points)
        {
            var rule = await _ruleRepository.GetByIdAsync(ruleId);
            if (rule == null)
                throw new Exception("Reward rule not found");

            rule.Update(condition, points);
            await _ruleRepository.UpdateAsync(rule);
            return rule;
        }

        // Get all Reward Rules
        public Task<IEnumerable<EventRewardRule>> GetAllRewardRulesAsync() => _ruleRepository.GetAllAsync();
    }
}
