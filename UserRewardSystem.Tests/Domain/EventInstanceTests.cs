using System;
using UserRewardSystem.Domain.Entities.Event;
using Xunit;

namespace UserRewardSystem.Tests.Domain
{
    public class EventInstanceTests
    {
        [Fact]
        public void Should_Create_EventInstance_Successfully()
        {
            var evId = Guid.NewGuid();
            var start = DateTime.UtcNow;
            var end = start.AddHours(2);

            var instance = new EventInstance(evId, start, end);

            Assert.Equal(evId, instance.EventId);
            Assert.False(instance.IsCompleted);
        }

        [Fact]
        public void Should_Mark_EventInstance_As_Completed()
        {
            var instance = new EventInstance(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddHours(2));

            instance.MarkCompleted();

            Assert.True(instance.IsCompleted);
        }
    }
}
