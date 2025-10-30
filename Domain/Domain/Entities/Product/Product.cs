using agdata.Domain.Common.Exceptions;
using Domain.Domain.Common;
using System;

namespace agdata.Domain.Entities.Product
{
    // Represents a product in the catalog
    public sealed class Product : BaseEntity
    {
        public string Name { get; } // Name of the product
        public string Description { get; } // Description of the product

        public Product(Guid id, string name, string description)
        {
            if (id == Guid.Empty)
                throw new ValidationException("Product ID cannot be empty"); // Validate ID

            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty"); // Validate name

            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Product description cannot be empty"); // Validate description

            Id = id;
            Name = name;
            Description = description;
        }

        // Returns a new Product instance with updated details
        public Product UpdateProduct(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Product name cannot be empty"); // Validate name

            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Product description cannot be empty"); // Validate description

            return new Product(Id, name, description); // Return updated instance
        }
    }
}
