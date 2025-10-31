using System;
using Xunit;
using UserRewardSystem.Domain.Entities.User;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Tests.Domain
{
    public class UserTests
    {
        //  USER TESTS 

        [Fact]
        public void CreateUser_ShouldInitializeValidUser()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var user = new User(id, "Khushia", "khushia@test.com", "E001", UserRole.Employee);

            // Assert
            Assert.Equal(id, user.Id);
            Assert.Equal("Khushia", user.Name);
            Assert.Equal("khushia@test.com", user.Email);
            Assert.Equal("E001", user.EmployeeId);
            Assert.Equal(UserRole.Employee, user.Role);
        }

        [Fact]
        public void CreateUser_ShouldThrow_WhenInvalidData()
        {
            // Arrange + Act + Assert
            Assert.Throws<ValidationException>(() => new User(Guid.Empty, "", "", "", UserRole.Employee));
        }

        [Fact]
        public void UpdateUser_ShouldChangeValues()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), "Old", "old@test.com", "E001", UserRole.Employee);

            // Act
            user.Update("New", "new@test.com", "E002", UserRole.Manager);

            // Assert
            Assert.Equal("New", user.Name);
            Assert.Equal("new@test.com", user.Email);
            Assert.Equal("E002", user.EmployeeId);
            Assert.Equal(UserRole.Manager, user.Role);
        }

        [Fact]
        public void UpdateUser_ShouldThrow_WhenEmptyFields()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), "Name", "email@test.com", "E001", UserRole.Employee);

            // Act + Assert
            Assert.Throws<ValidationException>(() => user.Update("", "", "", UserRole.Admin));
        }

        // USER ACCOUNT TESTS 

        [Fact]
        public void UserAccount_ShouldStartWithZeroPoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Assert
            Assert.Equal(0, acc.Points);
        }

        [Fact]
        public void UserAccount_ShouldAddPoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Act
            acc.AddPoints(100);

            // Assert
            Assert.Equal(100, acc.Points);
        }

        [Fact]
        public void UserAccount_ShouldThrow_WhenAddingNegativePoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Act + Assert
            Assert.Throws<ValidationException>(() => acc.AddPoints(-5));
        }

        [Fact]
        public void UserAccount_ShouldRedeemPoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());
            acc.AddPoints(200);

            // Act
            acc.RedeemPoints(50);

            // Assert
            Assert.Equal(150, acc.Points);
        }

        [Fact]
        public void UserAccount_ShouldThrow_WhenRedeemingTooManyPoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());
            acc.AddPoints(50);

            // Act + Assert
            Assert.Throws<ValidationException>(() => acc.RedeemPoints(100));
        }

        [Fact]
        public void UserAccount_ShouldThrow_WhenRedeemingNegativePoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Act + Assert
            Assert.Throws<ValidationException>(() => acc.RedeemPoints(-10));
        }

        [Fact]
        public void UserAccount_ShouldUpdatePointsDirectly()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Act
            acc.UpdatePoints(500);

            // Assert
            Assert.Equal(500, acc.Points);
        }

        [Fact]
        public void UserAccount_ShouldThrow_WhenUpdatingNegativePoints()
        {
            // Arrange
            var acc = new UserAccount(Guid.NewGuid());

            // Act + Assert
            Assert.Throws<ValidationException>(() => acc.UpdatePoints(-100));
        }
    }
}
