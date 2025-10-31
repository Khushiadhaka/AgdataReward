using System;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Domain.Entities.Product
{
    // Represents a product in the catalog
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }           // Product name
        public string Description { get; private set; }    // Product description
        public decimal Price { get; private set; }         // Product price
        public bool IsActive { get; private set; }         // Whether the product is active

        // Constructor for creating a new product
        public Product(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty"); // Validate name

            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Product description cannot be empty"); // Validate description

            if (price <= 0)
                throw new ValidationException("Product price must be greater than zero"); // Validate price

            Name = name;
            Description = description;
            Price = price;
            IsActive = true;
        }

        // Updates product details
        public void Update(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty");
            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Product description cannot be empty");
            if (price <= 0)
                throw new ValidationException("Product price must be greater than zero");

            Name = name;
            Description = description;
            Price = price;
            MarkUpdated(); // Update timestamp
        }

        // Deactivate product
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }

        // Reactivate product
        public void Activate()
        {
            IsActive = true;
            MarkUpdated();
        }
    }
}
