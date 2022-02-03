using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Interfaces;
using Test.Interfaces.IServices;
using Test.NoSQL.Interfaces;

namespace Test.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        //private readonly IProductCosmosRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _repo.DeleteProductAsync(productId);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repo.GetAllProductsAsync();
        }

        public async Task<Product> GetProductAsync(string productId)
        {
            return await _repo.GetProductAsync(productId);
        }

        public async Task<Product> SaveProductAsync(Product product)
        {
            return await _repo.SaveProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(string productId, Product product)
        {
            return await _repo.UpdateProductAsync(productId, product);
        }
    }
}