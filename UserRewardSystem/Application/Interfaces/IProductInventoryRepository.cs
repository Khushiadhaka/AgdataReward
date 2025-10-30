using System;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Product;

namespace UserRewardSystem.Application.Interfaces
{
    public interface IProductInventoryRepository
    {
        Task AddAsync(ProductInventory inventory);
        Task UpdateAsync(ProductInventory inventory);
        Task<ProductInventory> GetByProductIdAsync(Guid productId);
    }
}
