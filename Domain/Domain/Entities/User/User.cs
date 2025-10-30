using Domain.Domain.Common;
using Domain.Domain.Enums;
using System;

namespace Domain.Domain.Entities.User
{
    // Represents a user in the system
    public class User
    {
        public Guid Id { get; private set; }           // Unique user ID
        public string Name { get; private set; }       // User's full name
        public string Email { get; private set; }      // Email address
        public string EmployeeId { get; private set; } // Employee code or ID
        public UserRole Role { get; private set; }     // Role of the user

        // Constructor for new user creation
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

        // Method to update user details
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
