using System;
using System.Collections.Generic;
using DomainEvent = Domain.Domain.Entities.Event.Event;
using Domain.Domain.Entities.Event;

namespace Application.Interfaces
{
    // Event service interface defining operations for events
    public interface IEventService
    {
        EventDefinition CreateEventDefinition(string code, string title);
        // Create a new event type

        EventInstance CreateEventInstance(Guid eventDefinitionId);
        // Create a specific occurrence of an event

        void AssignWinner(Guid eventInstanceId, Guid userId, int rank);
        // Assign winner for an event instance

        void UpdateEventReward(Guid eventId, int rank, Guid rewardPointsId);
        // Update reward points for a rank

        IEnumerable<EventDefinition> GetAllEventDefinitions();
        // Get all event types

        IEnumerable<EventInstance> GetEventInstances(Guid eventDefinitionId);
        // Get all instances of a specific event
    }
}
