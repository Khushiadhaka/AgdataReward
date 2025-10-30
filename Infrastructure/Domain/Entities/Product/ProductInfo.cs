using Domain.Domain.Common;
using System;

namespace agdata.Domain.Entities.Product
{
    // Represents basic product details including SKU and linked reward points
    public sealed class ProductInfo
    {
        public Guid Id { get; } // Unique product ID
        public string SKU { get; } // Product SKU for inventory tracking
        public string Name { get; } // Product name
        public Guid RewardPointsId { get; } // Linked reward points ID

        public ProductInfo(Guid id, string sku, string name, Guid rewardPointsId)
        {
            if (id == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty"); // Validate ID

            if (string.IsNullOrWhiteSpace(sku))
                throw new ValidationException("Product SKU cannot be empty"); // Validate SKU

            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty"); // Validate name

            if (rewardPointsId == Guid.Empty)
                throw new ValidationException("RewardPointsId cannot be empty"); // Validate reward points

            Id = id;
            SKU = sku;
            Name = name;
            RewardPointsId = rewardPointsId;
        }

        // Returns a new ProductInfo instance with updated details
        public ProductInfo UpdateInfo(string sku, string name, Guid rewardPointsId)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new ValidationException("Product SKU cannot be empty"); // Validate SKU

            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty"); // Validate name

            if (rewardPointsId == Guid.Empty)
                throw new ValidationException("RewardPointsId cannot be empty"); // Validate reward points

            return new ProductInfo(Id, sku, name, rewardPointsId); // Create updated instance
        }
    }
}
