using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Product;

namespace UserRewardSystem.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(string name, string description, decimal price, int initialStock);
        Task<Product> UpdateProductAsync(Guid productId, string name, string description, decimal price);
        Task DeactivateProductAsync(Guid productId);
        Task ActivateProductAsync(Guid productId);

        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productId);

        Task IncreaseStockAsync(Guid productId, int quantity);
        Task ReduceStockAsync(Guid productId, int quantity);
    }
}
