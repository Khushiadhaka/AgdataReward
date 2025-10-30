using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.User;   
using UserRewardSystem.Domain.Enums;            
namespace UserRewardSystem.Application.Services
{
    // Implements IUserService
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountRepository _accountRepository;

        public UserService(IUserRepository userRepository, IUserAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        // Create new user and linked account
        public async Task<User> CreateUserAsync(string name, string email, string employeeId, UserRole role)
        {
            var user = new User(Guid.NewGuid(), name, email, employeeId, role);
            await _userRepository.AddAsync(user);

            var account = new UserAccount(user.Id);
            await _accountRepository.AddAsync(account);

            return user;
        }

        // Get all users
        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllAsync();

        // Get user by ID
        public Task<User> GetUserByIdAsync(Guid id) => _userRepository.GetByIdAsync(id);

        // Add reward points
        public async Task AddPointsAsync(Guid userId, int points)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId);
            if (account == null) throw new Exception("User account not found");

            account.AddPoints(points);
            await _accountRepository.UpdateAsync(account);
        }

        // Redeem reward points
        public async Task RedeemPointsAsync(Guid userId, int points)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId);
            if (account == null) throw new Exception("User account not found");

            account.RedeemPoints(points);
            await _accountRepository.UpdateAsync(account);
        }
    }
}
