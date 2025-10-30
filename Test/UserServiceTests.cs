using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Application.Services;
using UserRewardSystem.Domain.Enums;
using UserRewardSystem.Infrastructure.Repository;

namespace Test
{
    public class UserServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountRepository _accountRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            // Use in-memory repositories to simulate real DB
            _userRepository = new InMemoryUserRepository();
            _accountRepository = new InMemoryUserAccountRepository();
            _userService = new UserService(_userRepository, _accountRepository);
        }

        // Registering new user
        [Fact]
        public async Task CreateUser_Should_Create_User_And_Account()
        {
            var user = await _userService.CreateUserAsync("Khushia", "Khushia@test.com", "E001", UserRole.Employee);

            Assert.NotNull(user);
            Assert.Equal("Khushia", user.Name);
            Assert.Equal("Khushia@test.com", user.Email);

            var account = await _accountRepository.GetByUserIdAsync(user.Id);
            Assert.NotNull(account);
            Assert.Equal(0, account.Points);
        }

        //Duplicate user registration
        [Fact]
        public async Task CreateUser_Should_Throw_When_Email_Already_Exists()
        {
            await _userService.CreateUserAsync("Khushia", "duplicate@test.com", "E001", UserRole.Employee);

            await Assert.ThrowsAsync<Exception>(() =>
                _userService.CreateUserAsync("Another", "duplicate@test.com", "E002", UserRole.Manager));
        }

        //Add reward points
        [Fact]
        public async Task AddPoints_Should_Increase_Balance()
        {
            var user = await _userService.CreateUserAsync("B", "b@test.com", "E002", UserRole.Employee);
            await _userService.AddPointsAsync(user.Id, 200);

            var account = await _accountRepository.GetByUserIdAsync(user.Id);
            Assert.Equal(200, account.Points);
        }

        // Add negative points
        [Fact]
        public async Task AddPoints_Should_Throw_When_Points_Negative()
        {
            var user = await _userService.CreateUserAsync("C", "c@test.com", "E003", UserRole.Employee);

            await Assert.ThrowsAsync<Exception>(() =>
                _userService.AddPointsAsync(user.Id, -50));
        }

        // Redeem points successfully
        [Fact]
        public async Task RedeemPoints_Should_Decrease_Balance()
        {
            var user = await _userService.CreateUserAsync("D", "d@test.com", "E004", UserRole.Employee);
            await _userService.AddPointsAsync(user.Id, 300);
            await _userService.RedeemPointsAsync(user.Id, 100);

            var account = await _accountRepository.GetByUserIdAsync(user.Id);
            Assert.Equal(200, account.Points);
        }

        // Redeem more points than balance
        [Fact]
        public async Task RedeemPoints_Should_Throw_When_Insufficient_Balance()
        {
            var user = await _userService.CreateUserAsync("E", "e@test.com", "E005", UserRole.Employee);
            await _userService.AddPointsAsync(user.Id, 50);

            await Assert.ThrowsAsync<Exception>(() =>
                _userService.RedeemPointsAsync(user.Id, 200));
        }

        // Redeem negative points
        [Fact]
        public async Task RedeemPoints_Should_Throw_When_Negative_Points()
        {
            var user = await _userService.CreateUserAsync("F", "f@test.com", "E006", UserRole.Employee);

            await Assert.ThrowsAsync<Exception>(() =>
                _userService.RedeemPointsAsync(user.Id, -10));
        }

        //Get all users
        [Fact]
        public async Task GetAllUsers_Should_Return_All_Registered_Users()
        {
            await _userService.CreateUserAsync("User1", "u1@test.com", "E007", UserRole.Employee);
            await _userService.CreateUserAsync("User2", "u2@test.com", "E008", UserRole.Manager);

            var users = await _userService.GetAllUsersAsync();
            Assert.True(users != null && users.Any());
            Assert.Equal(2, users.Count());
        }

        // Get user by ID
        [Fact]
        public async Task GetUserById_Should_Return_Correct_User()
        {
            var user = await _userService.CreateUserAsync("Jack", "jack@test.com", "E009", UserRole.Manager);
            var fetched = await _userService.GetUserByIdAsync(user.Id);

            Assert.NotNull(fetched);
            Assert.Equal("jack@test.com", fetched.Email);
        }

        //Get user by invalid ID
        [Fact]
        public async Task GetUserById_Should_Return_Null_For_Invalid_Id()
        {
            var result = await _userService.GetUserByIdAsync(Guid.NewGuid());
            Assert.Null(result);
        }
    }
}
