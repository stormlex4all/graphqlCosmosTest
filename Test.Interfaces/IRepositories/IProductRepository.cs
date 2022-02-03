using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SaveProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string productId);
        Task<Product> UpdateProductAsync(string productId, Product product);
        Task DeleteProductAsync(string productId);
    }
}