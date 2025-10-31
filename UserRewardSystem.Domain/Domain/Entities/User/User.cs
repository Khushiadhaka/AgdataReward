using System;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Domain.Entities.User
{
    // Represents an application user
    public class User
    {
        public Guid Id { get; private set; }           // Unique user ID
        public string Name { get; private set; }       // User name
        public string Email { get; private set; }      // User email
        public string EmployeeId { get; private set; } // Employee ID
        public UserRole Role { get; private set; }     // Role (Employee/Manager/Admin)

        // Constructor initializes user with validation
        public User(Guid id, string name, string email, string employeeId, UserRole role)
        {
            if (id == Guid.Empty) throw new ValidationException("User ID cannot be empty");
            if (string.IsNullOrWhiteSpace(name)) throw new ValidationException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(email)) throw new ValidationException("Email cannot be empty");
            if (string.IsNullOrWhiteSpace(employeeId)) throw new ValidationException("Employee ID cannot be empty");

            Id = id;
            Name = name;
            Email = email;
            EmployeeId = employeeId;
            Role = role;
        }

        // Updates user details with validation
        public void Update(string name, string email, string employeeId, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ValidationException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(email)) throw new ValidationException("Email cannot be empty");
            if (string.IsNullOrWhiteSpace(employeeId)) throw new ValidationException("Employee ID cannot be empty");

            Name = name;
            Email = email;
            EmployeeId = employeeId;
            Role = role;
        }
    }
}
