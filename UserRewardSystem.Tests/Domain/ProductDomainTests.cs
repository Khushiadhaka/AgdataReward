using System;
using Xunit;
using UserRewardSystem.Domain.Entities.Product;
using UserRewardSystem.Domain.Common;

namespace UserRewardSystem.Tests.Domain
{
    public class ProductDomainTests
    {
        //PRODUCT TESTS

        [Fact]
        public void CreateProduct_ShouldInitializeCorrectly()
        {
            var product = new Product("Laptop", "High-end gaming laptop", 1500m);

            Assert.Equal("Laptop", product.Name);
            Assert.Equal("High-end gaming laptop", product.Description);
            Assert.Equal(1500m, product.Price);
            Assert.True(product.IsActive);
        }

        [Fact]
        public void CreateProduct_ShouldThrow_WhenNameEmpty()
        {
            Assert.Throws<ValidationException>(() => new Product("", "Description", 100m));
        }

        [Fact]
        public void CreateProduct_ShouldThrow_WhenDescriptionEmpty()
        {
            Assert.Throws<ValidationException>(() => new Product("Name", "", 100m));
        }

        [Fact]
        public void CreateProduct_ShouldThrow_WhenPriceInvalid()
        {
            Assert.Throws<ValidationException>(() => new Product("Name", "Desc", 0));
        }

        [Fact]
        public void UpdateProduct_ShouldChangeValues_AndMarkUpdated()
        {
            var product = new Product("Pen", "Blue ink", 10m);
            var updatedTime = product.UpdatedAt;

            product.Update("Marker", "Permanent marker", 25m);

            Assert.Equal("Marker", product.Name);
            Assert.Equal("Permanent marker", product.Description);
            Assert.Equal(25m, product.Price);
            Assert.True(product.UpdatedAt > updatedTime);
        }

        [Fact]
        public void DeactivateProduct_ShouldSetInactive()
        {
            var product = new Product("Pen", "Blue ink", 10m);
            product.Deactivate();

            Assert.False(product.IsActive);
        }

        [Fact]
        public void ActivateProduct_ShouldSetActive()
        {
            var product = new Product("Pen", "Blue ink", 10m);
            product.Deactivate();
            product.Activate();

            Assert.True(product.IsActive);
        }

        //PRODUCT INFO TESTS

        [Fact]
        public void CreateProductInfo_ShouldInitializeCorrectly()
        {
            var productId = Guid.NewGuid();
            var rewardId = Guid.NewGuid();

            var info = new ProductInfo(productId, "SKU001", "Laptop", rewardId);

            Assert.Equal(productId, info.ProductId);
            Assert.Equal("SKU001", info.SKU);
            Assert.Equal("Laptop", info.Name);
            Assert.Equal(rewardId, info.RewardPointId);
        }

        [Fact]
        public void CreateProductInfo_ShouldThrow_WhenInvalid()
        {
            var productId = Guid.NewGuid();
            var rewardId = Guid.NewGuid();

            Assert.Throws<ValidationException>(() => new ProductInfo(Guid.Empty, "SKU001", "Laptop", rewardId));
            Assert.Throws<ValidationException>(() => new ProductInfo(productId, "", "Laptop", rewardId));
            Assert.Throws<ValidationException>(() => new ProductInfo(productId, "SKU001", "", rewardId));
            Assert.Throws<ValidationException>(() => new ProductInfo(productId, "SKU001", "Laptop", Guid.Empty));
        }

        [Fact]
        public void UpdateProductInfo_ShouldReturnUpdatedInstance()
        {
            var productId = Guid.NewGuid();
            var rewardId = Guid.NewGuid();

            var info = new ProductInfo(productId, "SKU001", "Laptop", rewardId);
            var newRewardId = Guid.NewGuid();

            var updatedInfo = info.Update("SKU002", "Monitor", newRewardId);

            Assert.Equal(productId, updatedInfo.ProductId);
            Assert.Equal("SKU002", updatedInfo.SKU);
            Assert.Equal("Monitor", updatedInfo.Name);
            Assert.Equal(newRewardId, updatedInfo.RewardPointId);
        }

        // 🔹 PRODUCT INVENTORY TESTS

        [Fact]
        public void CreateInventory_ShouldInitializeCorrectly()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 50);

            Assert.Equal(50, inv.StockQuantity);
            Assert.True(inv.IsActive);
        }

        [Fact]
        public void CreateInventory_ShouldThrow_WhenInvalid()
        {
            Assert.Throws<ValidationException>(() => new ProductInventory(Guid.Empty, 10));
            Assert.Throws<ValidationException>(() => new ProductInventory(Guid.NewGuid(), -5));
        }

        [Fact]
        public void IncreaseStock_ShouldAddQuantity_AndMarkUpdated()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 10);
            var oldStock = inv.StockQuantity;
            var oldTime = inv.UpdatedAt;

            inv.IncreaseStock(5);

            Assert.Equal(oldStock + 5, inv.StockQuantity);
            Assert.True(inv.UpdatedAt > oldTime);
        }

        [Fact]
        public void ReduceStock_ShouldSubtractQuantity()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 10);
            inv.ReduceStock(5);
            Assert.Equal(5, inv.StockQuantity);
        }

        [Fact]
        public void ReduceStock_ShouldThrow_WhenInvalid()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 10);
            Assert.Throws<ValidationException>(() => inv.ReduceStock(0));
            Assert.Throws<ValidationException>(() => inv.ReduceStock(15));
        }

        [Fact]
        public void DeactivateInventory_ShouldSetInactive()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 10);
            inv.Deactivate();
            Assert.False(inv.IsActive);
        }

        [Fact]
        public void ActivateInventory_ShouldSetActive()
        {
            var inv = new ProductInventory(Guid.NewGuid(), 10);
            inv.Deactivate();
            inv.Activate();
            Assert.True(inv.IsActive);
        }
    }
}

