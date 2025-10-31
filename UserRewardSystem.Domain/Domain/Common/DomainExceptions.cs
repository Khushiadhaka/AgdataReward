using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRewardSystem.Domain.Common
{
    // Base domain-level exception
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }

    // Validation error
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message) { }
    }

    // Entity not found error
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) { }
    }

    // Business rule violation
    public class BusinessRuleException : DomainException
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
