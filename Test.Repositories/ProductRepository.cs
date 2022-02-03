using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using Test.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Test.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CosmosDbContext _context;
        //private readonly TestDbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(
            CosmosDbContext context
            )
        {
            _context = context;
            _products = context.Products;
        }

        public async Task DeleteProductAsync(string productId)
        {
            var product = await GetProductAsync(productId);
            _products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(string productId)
        {
            var product = await _products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                throw new Exception("Product does not exist");
            }
            return product;
        }

        public async Task<Product> SaveProductAsync(Product product)
        {
            if (product.Id != default)
            {
                var products = await _products.ToListAsync();
                if (products.Any(p => p.Id == product.Id))
                {
                    throw new Exception("Product already not exists!");
                }
            }
            await _products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(string productId, Product product)
        {
            var _product = await GetProductAsync(productId);
            _product.Name = product.Name;
            _product.Description = product.Description;

            _context.Update(_product);
            await _context.SaveChangesAsync();
            return await _products.FirstAsync(p => p.Id == productId);
        }
    }
}