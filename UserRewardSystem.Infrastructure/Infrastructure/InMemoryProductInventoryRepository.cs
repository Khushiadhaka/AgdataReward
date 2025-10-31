using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Product;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryProductInventoryRepository : IProductInventoryRepository
    {
        private readonly List<ProductInventory> _inventories = new List<ProductInventory>();

        public Task AddAsync(ProductInventory inventory)
        {
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ProductInventory inventory) => Task.CompletedTask;

        public Task<ProductInventory> GetByProductIdAsync(Guid productId) =>
            Task.FromResult(_inventories.FirstOrDefault(i => i.ProductId == productId));
    }
}
