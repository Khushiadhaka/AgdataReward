using Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities.Redemption
{
    // Represents a record of a product redemption by a user
    public sealed class RedemptionRecord
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ProductId { get; }

        public RedemptionRecord(Guid id, Guid userId, Guid productId)
        {
            if (id == Guid.Empty) throw new ValidationException("RedemptionRecord ID cannot be empty.");
            if (userId == Guid.Empty) throw new ValidationException("User ID cannot be empty.");
            if (productId == Guid.Empty) throw new ValidationException("Product ID cannot be empty.");

            Id = id;
            UserId = userId;
            ProductId = productId;
        }
    }
}
