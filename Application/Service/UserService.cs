using System;                                          
using System.Collections.Generic;                       
using System.Linq;                                      
using System.Threading.Tasks;                           
using Domain.Domain.Entities.User;                      
using Domain.Domain.Enums;                              
using Domain.Domain.Common;                             
using Application.Interfaces;                           

namespace Application.Services
{
    // Service class handling user-related business logic
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;             // Repository for managing users
        private readonly IUserAccountRepository _accountRepository;   // Repository for managing user accounts

        // Constructor to inject repositories (Dependency Injection)
        public UserService(IUserRepository userRepository, IUserAccountRepository accountRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));  // Ensure not null
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository)); // Ensure not null
        }

        // Register a new user in the system
        public async Task<User> RegisterUserAsync(string name, string email, string employeeId, UserRole role)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(name)) throw new ValidationException("Name is required");
            if (string.IsNullOrWhiteSpace(email)) throw new ValidationException("Email is required");
            if (string.IsNullOrWhiteSpace(employeeId)) throw new ValidationException("Employee ID is required");

            // Check for duplicate email or employee ID
            var users = await _userRepository.ListAsync();
            if (users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) ||
                              u.EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase)))
                throw new ValidationException("User with same email or employee ID already exists");

            // Create a new user entity
            var newUser = new User(Guid.NewGuid(), name, email, employeeId, role);

            // Save new user to repository
            await _userRepository.AddAsync(newUser);

            // Create a user account for reward points
            var account = new UserAccount(newUser.Id);
            _accountRepository.Add(account);

            // Return newly registered user
            return newUser;
        }

        // Retrieve all users
        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.ListAsync();

        // Get user by unique ID
        public async Task<User> GetByIdAsync(Guid id) => await _userRepository.GetByIdAsync(id);

        // Get user by email address
        public async Task<User> GetByEmailAsync(string email) => await _userRepository.GetByEmailAsync(email);

        // Update an existing user's details
        public async Task UpdateUserAsync(Guid userId, string name, string email, string employeeId, UserRole role)
        {
            // Find existing user
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new ValidationException("User not found");

            // Update user entity
            user.Update(name, email, employeeId, role);

            // Save changes
            await _userRepository.UpdateAsync(user);
        }

        // Add reward points to a user's account
        public void AddPoints(Guid userId, int points)
        {
            if (points <= 0)
                throw new ValidationException("Points must be greater than zero");

            var account = _accountRepository.GetByUserId(userId)
                ?? throw new ValidationException("User account not found");

            account.AddPoints(points);            // Add points
            _accountRepository.Update(account);   // Update repository
        }

        // Redeem points from user's account
        public void RedeemPoints(Guid userId, int points)
        {
            if (points <= 0)
                throw new ValidationException("Points must be greater than zero");

            var account = _accountRepository.GetByUserId(userId)
                ?? throw new ValidationException("User account not found");

            account.RedeemPoints(points);         // Deduct points
            _accountRepository.Update(account);   // Update repository
        }

        // Get total balance of user's points
        public int GetPointsBalance(Guid userId)
        {
            var account = _accountRepository.GetByUserId(userId)
                ?? throw new ValidationException("User account not found");

            return account.Points;                // Return current point balance
        }
    }
}
