using System;
using System.Threading.Tasks;
using Xunit;
using UserRewardSystem.Application.Services;
using UserRewardSystem.Infrastructure.Repository;
using UserRewardSystem.Domain.Entities.Event;

namespace UserRewardSystem.Tests
{
    public class EventTests
    {
        private readonly EventService _service;

        public EventTests()
        {
            // Initialize in-memory repositories
            var eventRepo = new InMemoryEventRepository();
            var defRepo = new InMemoryEventDefinitionRepository();
            var instanceRepo = new InMemoryEventInstanceRepository();
            var ruleRepo = new InMemoryEventRewardRuleRepository();

            // Inject into service
            _service = new EventService(eventRepo, defRepo, instanceRepo, ruleRepo);
        }

        // Test 1: Create a new event definition
        [Fact]
        public async Task CreateEventDefinition_ShouldReturnDefinitionWithCorrectValues()
        {
            var definition = await _service.CreateEventDefinitionAsync("Hackathon", "Annual coding event", 100);

            Assert.NotNull(definition);
            Assert.Equal("Hackathon", definition.Name);
            Assert.Equal(100, definition.RewardPoints);
        }

        // Test 2: Schedule a new event using a definition
        [Fact]
        public async Task ScheduleEvent_ShouldCreateEventSuccessfully()
        {
            var def = await _service.CreateEventDefinitionAsync("Webinar", "Tech webinar", 50);
            var scheduledDate = new DateTime(2025, 12, 25);

            var ev = await _service.ScheduleEventAsync(def.Id, scheduledDate);

            Assert.NotNull(ev);
            Assert.Equal(def.Id, ev.EventDefinitionId);
            Assert.Equal(scheduledDate, ev.ScheduledDate);
        }

        // Test 3: Reschedule an existing event
        [Fact]
        public async Task RescheduleEvent_ShouldChangeDateSuccessfully()
        {
            var def = await _service.CreateEventDefinitionAsync("Workshop", "Training session", 75);
            var ev = await _service.ScheduleEventAsync(def.Id, DateTime.Today);

            var newDate = DateTime.Today.AddDays(5);
            await _service.RescheduleEventAsync(ev.Id, newDate);

            Assert.Equal(newDate, ev.ScheduledDate);
        }

        //Test 4: Create and complete an event instance
        [Fact]
        public async Task CreateAndCompleteEventInstance_ShouldMarkAsCompleted()
        {
            var def = await _service.CreateEventDefinitionAsync("Hackathon", "Big event", 200);
            var ev = await _service.ScheduleEventAsync(def.Id, DateTime.Today);

            var instance = await _service.CreateEventInstanceAsync(ev.Id, DateTime.Now, DateTime.Now.AddHours(3));

            await _service.CompleteEventInstanceAsync(instance.Id);

            Assert.True(instance.IsCompleted);
        }

        //Test 5: Exception when completing non-existing event instance
        [Fact]
        public async Task CompleteEventInstance_ShouldThrow_WhenInstanceNotFound()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                _service.CompleteEventInstanceAsync(Guid.NewGuid()));

            Assert.Equal("Event instance not found", ex.Message);
        }

        //Test 6: Exception when rescheduling non-existing event
        [Fact]
        public async Task RescheduleEvent_ShouldThrow_WhenEventNotFound()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                _service.RescheduleEventAsync(Guid.NewGuid(), DateTime.Today.AddDays(1)));

            Assert.Equal("Event not found", ex.Message);
        }
    }
}

