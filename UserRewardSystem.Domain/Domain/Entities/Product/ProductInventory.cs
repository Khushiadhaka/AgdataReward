using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Product
{
    // Represents product inventory details
    public sealed class ProductInventory : BaseEntity
    {
        public Guid ProductId { get; private set; }     // Linked product ID
        public int StockQuantity { get; private set; }  // Available stock quantity
        public bool IsActive { get; private set; }      // Inventory status

        public ProductInventory(Guid productId, int stockQuantity)
        {
            if (productId == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty");
            if (stockQuantity < 0)
                throw new ValidationException("Stock quantity cannot be negative");

            ProductId = productId;
            StockQuantity = stockQuantity;
            IsActive = true;
        }

        // Increase stock
        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero");

            StockQuantity += quantity;
            MarkUpdated();
        }

        // Reduce stock
        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero");
            if (quantity > StockQuantity)
                throw new ValidationException("Insufficient stock");

            StockQuantity -= quantity;
            MarkUpdated();
        }

        // Deactivate inventory
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }

        // Reactivate inventory
        public void Activate()
        {
            IsActive = true;
            MarkUpdated();
        }
    }
}
