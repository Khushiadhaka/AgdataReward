using Domain.Domain.Common;
using System;

namespace agdata.Domain.Entities.Product
{
    // Represents inventory details for a product
    public sealed class ProductInventory
    {
        public Guid ProductId { get; } // ID of the product
        public int StockQuantity { get; private set; } // Current stock quantity
        public bool IsActive { get; private set; } // Inventory status

        public ProductInventory(Guid productId, int stockQuantity)
        {
            if (productId == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty"); // Validate ID

            if (stockQuantity < 0)
                throw new ValidationException("Stock quantity cannot be negative"); // Validate stock

            ProductId = productId;
            StockQuantity = stockQuantity;
            IsActive = true; // Default inventory status
        }

        // Reduces stock by specified quantity
        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero"); // Validate quantity

            if (StockQuantity < quantity)
                throw new ValidationException("Insufficient stock"); // Validate stock

            StockQuantity -= quantity; // Reduce stock
        }

        // Increases stock by specified quantity
        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero"); // Validate quantity

            StockQuantity += quantity; // Add stock
        }

        // Deactivates the inventory
        public void Deactivate() => IsActive = false; // Set inventory inactive
    }
}
