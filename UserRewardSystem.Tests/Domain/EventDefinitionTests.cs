using System;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Entities.Event;
using Xunit;

namespace UserRewardSystem.Tests.Domain
{
    public class EventDefinitionTests
    {
        [Fact]
        public void Should_Create_EventDefinition_Successfully()
        {
            // Arrange & Act
            var eventDef = new EventDefinition("Purchase", "User made a purchase", 100);

            // Assert
            Assert.Equal("Purchase", eventDef.Name);
            Assert.Equal("User made a purchase", eventDef.Description);
            Assert.Equal(100, eventDef.RewardPoints);
            Assert.NotEqual(Guid.Empty, eventDef.Id);
        }

        [Fact]
        public void Should_Throw_When_Name_Is_Empty()
        {
            // Assert
            Assert.Throws<ValidationException>(() => new EventDefinition("", "No name", 50));
        }

        [Fact]
        public void Should_Throw_When_RewardPoints_Are_Negative()
        {
            // Assert
            Assert.Throws<ValidationException>(() => new EventDefinition("Test Event", "Invalid Points", -5));
        }

        [Fact]
        public void Update_Should_Change_Values_Correctly()
        {
            // Arrange
            var eventDef = new EventDefinition("Old", "Old description", 10);

            // Act
            eventDef.Update("New", "New description", 50);

            // Assert
            Assert.Equal("New", eventDef.Name);
            Assert.Equal("New description", eventDef.Description);
            Assert.Equal(50, eventDef.RewardPoints);
        }

        [Fact]
        public void Update_Should_Throw_When_NewName_Is_Empty()
        {
            // Arrange
            var eventDef = new EventDefinition("Valid", "Valid desc", 10);

            // Assert
            Assert.Throws<ValidationException>(() => eventDef.Update("", "desc", 10));
        }

        [Fact]
        public void Update_Should_Throw_When_NewRewardPoints_Invalid()
        {
            // Arrange
            var eventDef = new EventDefinition("Valid", "Valid desc", 10);

            // Assert
            Assert.Throws<ValidationException>(() => eventDef.Update("Updated", "desc", 0));
        }
    }
}
