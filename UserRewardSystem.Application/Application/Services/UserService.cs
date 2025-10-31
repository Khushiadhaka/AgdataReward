using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Entities.User;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Application.Services
{
    // Implements business logic for user management
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;             // User repository dependency
        private readonly IUserAccountRepository _accountRepository;   // User account repository dependency

        // Constructor injection for repositories
        public UserService(IUserRepository userRepository, IUserAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        // Creates a new user and their reward account
        public async Task<User> CreateUserAsync(string name, string email, string employeeId, UserRole role)
        {
            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null)
                throw new ValidationException("User with this email already exists.");

            var user = new User(Guid.NewGuid(), name, email, employeeId, role);
            await _userRepository.AddAsync(user);

            var account = new UserAccount(user.Id);
            await _accountRepository.AddAsync(account);

            return user;
        }

        // Gets all users from repository
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Gets user details by ID
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // Adds reward points to user's account
        public async Task AddPointsAsync(Guid userId, int points)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId);
            if (account == null) throw new ValidationException("User account not found.");

            account.AddPoints(points);
            await _accountRepository.UpdateAsync(account);
        }

        // Redeems reward points from user's account
        public async Task RedeemPointsAsync(Guid userId, int points)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId);
            if (account == null) throw new ValidationException("User account not found.");

            account.RedeemPoints(points);
            await _accountRepository.UpdateAsync(account);
        }
    }
}
