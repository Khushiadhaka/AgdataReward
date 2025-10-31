using System;
using UserRewardSystem.Domain.Entities.Event;
using Xunit;

namespace UserRewardSystem.Tests.Domain
{
    public class EventTests
    {
        [Fact]
        public void Should_Create_Event_With_DefinitionId_And_Date()
        {
            var defId = Guid.NewGuid();
            var ev = new Event(defId, DateTime.UtcNow);

            Assert.Equal(defId, ev.EventDefinitionId);
        }

        [Fact]
        public void Should_Reschedule_Event()
        {
            var ev = new Event(Guid.NewGuid(), DateTime.UtcNow);
            var newDate = DateTime.UtcNow.AddDays(2);

            ev.Reschedule(newDate);

            Assert.Equal(newDate, ev.ScheduledDate);
        }
    }
}
