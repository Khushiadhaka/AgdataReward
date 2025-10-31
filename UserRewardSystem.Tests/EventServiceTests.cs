using System;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Services;
using UserRewardSystem.Infrastructure.Repository;
using Xunit;

namespace UserRewardSystem.Tests.Services
{
    public class EventServiceTests
    {
        private readonly EventService _service;

        public EventServiceTests()
        {
            var eventRepo = new InMemoryEventRepository();
            var defRepo = new InMemoryEventDefinitionRepository();
            var instanceRepo = new InMemoryEventInstanceRepository();
            var ruleRepo = new InMemoryEventRewardRuleRepository();

            _service = new EventService(eventRepo, defRepo, instanceRepo, ruleRepo);
        }

        [Fact]
        public async Task Should_Create_EventDefinition()
        {
            var def = await _service.CreateEventDefinitionAsync("Hackathon", "Test Event", 100);

            Assert.NotNull(def);
            Assert.Equal("Hackathon", def.Name);
        }

        [Fact]
        public async Task Should_Schedule_And_Reschedule_Event()
        {
            var def = await _service.CreateEventDefinitionAsync("Demo", "Desc", 50);
            var ev = await _service.ScheduleEventAsync(def.Id, DateTime.UtcNow.AddDays(1));

            var newDate = DateTime.UtcNow.AddDays(5);
            await _service.RescheduleEventAsync(ev.Id, newDate);

            var updatedEvent = await _service.GetEventByIdAsync(ev.Id);
            Assert.Equal(newDate, updatedEvent.ScheduledDate);
        }

        [Fact]
        public async Task Should_Create_And_Complete_EventInstance()
        {
            var def = await _service.CreateEventDefinitionAsync("Demo", "Desc", 50);
            var ev = await _service.ScheduleEventAsync(def.Id, DateTime.UtcNow);

            var instance = await _service.CreateEventInstanceAsync(ev.Id, DateTime.UtcNow, DateTime.UtcNow.AddHours(2));
            Assert.NotNull(instance);

            await _service.CompleteEventInstanceAsync(instance.Id);
            var updated = await _service.GetEventInstanceByIdAsync(instance.Id);

            Assert.True(updated.IsCompleted);
        }

        [Fact]
        public async Task Should_Create_And_Update_RewardRule()
        {
            var def = await _service.CreateEventDefinitionAsync("RewardEvent", "Desc", 20);

            var rule = await _service.CreateRewardRuleAsync(def.Id, "Completed", 10);
            Assert.Equal("Completed", rule.Condition);

            var updated = await _service.UpdateRewardRuleAsync(rule.Id, "Participation", 25);
            Assert.Equal("Participation", updated.Condition);
            Assert.Equal(25, updated.Points);
        }
    }
}
