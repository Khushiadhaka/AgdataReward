using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Product;

namespace UserRewardSystem.Infrastructure.Repository
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product) => Task.CompletedTask;

        public Task<Product> GetByIdAsync(Guid id) =>
            Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

        public Task<IEnumerable<Product>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Product>>(_products);
    }
}
