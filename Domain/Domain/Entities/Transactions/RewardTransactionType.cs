using Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities.Transactions
{
    // Represents a type/category of points transaction
    public sealed class RewardTransactionType
    {
        public Guid Id { get; }
        public string TypeName { get; }

        public RewardTransactionType(Guid id, string typeName)
        {
            if (id == Guid.Empty) throw new ValidationException("Transaction type ID cannot be empty.");
            if (string.IsNullOrWhiteSpace(typeName)) throw new ValidationException("Transaction type name cannot be empty.");

            Id = id;
            TypeName = typeName;
        }
    }
}
