using agdata.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // Product service interface defining operations for catalog management
    // Product service interface for catalog management
    public interface IProductService
    {
        Product CreateProduct(string name, string description);
        // Add a new product

        Product UpdateProduct(Guid productId, string name, string description);
        // Update product details

        ProductInfo AddProductInfo(Guid productId, string sku, string name, Guid rewardPointsId);
        // Add product info

        void UpdateProductInfo(Guid productInfoId, string sku, string name, Guid rewardPointsId);
        // Update product info

        ProductInventory AddInventory(Guid productId, int stock);
        // Add inventory for product

        void ReduceStock(Guid productId, int qty);
        // Reduce product stock

        void IncreaseStock(Guid productId, int qty);
        // Increase stock

        void DeactivateProduct(Guid productId);
        // Deactivate product

        IEnumerable<Product> GetAllProducts();
        // Get all products
    }
}
