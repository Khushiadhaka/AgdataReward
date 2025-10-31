using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Application.Interfaces
{
    public interface IEventService
    {
        // Definitions
        Task<EventDefinition> CreateEventDefinitionAsync(string name, string description, int rewardPoints);
        Task<EventDefinition> UpdateEventDefinitionAsync(Guid definitionId, string name, string description, int rewardPoints);
        Task<IEnumerable<EventDefinition>> GetAllEventDefinitionsAsync();
        Task<EventDefinition> GetEventDefinitionByIdAsync(Guid id);

        // Events
        Task<Event> ScheduleEventAsync(Guid definitionId, DateTime scheduledDate);
        Task<Event> RescheduleEventAsync(Guid eventId, DateTime newDate);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(Guid id);

        // Instances
        Task<EventInstance> CreateEventInstanceAsync(Guid eventId, DateTime startTime, DateTime endTime);
        Task<EventInstance> CompleteEventInstanceAsync(Guid instanceId);
        Task<IEnumerable<EventInstance>> GetAllEventInstancesAsync();
        Task<EventInstance> GetEventInstanceByIdAsync(Guid id);

        // Reward Rules
        Task<EventRewardRule> CreateRewardRuleAsync(Guid definitionId, string condition, int points);
        Task<EventRewardRule> UpdateRewardRuleAsync(Guid ruleId, string condition, int points);
        Task<IEnumerable<EventRewardRule>> GetAllRewardRulesAsync();
    }
}

