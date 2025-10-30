using System;
using UserRewardSystem.Domain.Common;  // For ValidationException
using UserRewardSystem.Domain.Enums;   // For UserRole enum

namespace UserRewardSystem.Domain.Entities.User
{// Represents a system user
    public class User
    {
        public Guid Id { get; private set; }           // Unique user ID
        public string Name { get; private set; }       // User's name
        public string Email { get; private set; }      // User's email
        public string EmployeeId { get; private set; } // Employee ID
        public UserRole Role { get; private set; }     // User role

        // Constructor
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

        // Update user details
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

