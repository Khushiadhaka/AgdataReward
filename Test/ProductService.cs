using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Product;

namespace Test
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductInventoryRepository _inventoryRepository;

        public ProductService(IProductRepository productRepository, IProductInventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }

        // Create new product + initial inventory
        public async Task<Product> CreateProductAsync(string name, string description, decimal price, int initialStock)
        {
            var product = new Product(name, description, price);
            await _productRepository.AddAsync(product);

            var inventory = new ProductInventory(product.Id, initialStock);
            await _inventoryRepository.AddAsync(inventory);

            return product;
        }

        // Update product details
        public async Task<Product> UpdateProductAsync(Guid productId, string name, string description, decimal price)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Update(name, description, price);
            await _productRepository.UpdateAsync(product);
            return product;
        }

        // Activate/Deactivate
        public async Task DeactivateProductAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Deactivate();
            await _productRepository.UpdateAsync(product);
        }

        public async Task ActivateProductAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Activate();
            await _productRepository.UpdateAsync(product);
        }

        // Get methods
        public Task<IEnumerable<Product>> GetAllProductsAsync() => _productRepository.GetAllAsync();

        public Task<Product> GetProductByIdAsync(Guid productId) => _productRepository.GetByIdAsync(productId);

        // Stock control
        public async Task IncreaseStockAsync(Guid productId, int quantity)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(productId);
            if (inventory == null)
                throw new Exception("Inventory not found");

            inventory.IncreaseStock(quantity);
            await _inventoryRepository.UpdateAsync(inventory);
        }

        public async Task ReduceStockAsync(Guid productId, int quantity)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(productId);
            if (inventory == null)
                throw new Exception("Inventory not found");

            inventory.ReduceStock(quantity);
            await _inventoryRepository.UpdateAsync(inventory);
        }
    }
}
