using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Product
{
    // Represents summary information for a product (used in reward linkage)
    public sealed class ProductInfo
    {
        public Guid ProductId { get; }           // Product unique ID
        public string SKU { get; }               // Stock keeping unit
        public string Name { get; }              // Product name
        public Guid RewardPointId { get; }       // Linked reward point ID

        public ProductInfo(Guid productId, string sku, string name, Guid rewardPointId)
        {
            if (productId == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty");
            if (string.IsNullOrWhiteSpace(sku))
                throw new ValidationException("SKU cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty");
            if (rewardPointId == Guid.Empty)
                throw new ValidationException("Reward point ID cannot be empty");

            ProductId = productId;
            SKU = sku;
            Name = name;
            RewardPointId = rewardPointId;
        }

        // Create an updated copy
        public ProductInfo Update(string sku, string name, Guid rewardPointId)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new ValidationException("SKU cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty");
            if (rewardPointId == Guid.Empty)
                throw new ValidationException("Reward point ID cannot be empty");

            return new ProductInfo(ProductId, sku, name, rewardPointId);
        }
    }
}
