using System;
using UserRewardSystem.Domain.Entities.Event;
using Xunit;

namespace UserRewardSystem.Tests.Domain
{
    public class EventRewardRuleTests
    {
        [Fact]
        public void Should_Create_RewardRule_Successfully()
        {
            var rule = new EventRewardRule(Guid.NewGuid(), "Completed", 50);

            Assert.Equal("Completed", rule.Condition);
            Assert.Equal(50, rule.Points);
        }

        [Fact]
        public void Should_Update_RewardRule_Successfully()
        {
            var rule = new EventRewardRule(Guid.NewGuid(), "Old Condition", 20);

            rule.Update("New Condition", 40);

            Assert.Equal("New Condition", rule.Condition);
            Assert.Equal(40, rule.Points);
        }
    }
}

