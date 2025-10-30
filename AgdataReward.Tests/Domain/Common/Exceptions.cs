using System;

namespace Domain.Domain.Common
{
    // Base exception for domain-level errors
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { } // Custom domain exception message
    }

    // Thrown when validation fails (e.g., invalid data or constraints)
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message) { } // Validation-specific error
    }

    // Thrown when an entity is not found in the repository
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) { } // Entity not found error
    }

    // Thrown when a business rule is violated
    public class BusinessRuleException : DomainException
    {
        public BusinessRuleException(string message) : base(message) { } // Business rule violation
    }
}
