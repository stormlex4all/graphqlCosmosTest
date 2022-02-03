using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Interfaces.IServices
{
    public interface IProductService
    {
        Task<Product> SaveProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string productId);
        Task<Product> UpdateProductAsync(string productId, Product product);
        Task DeleteProductAsync(string productId);
    }
}
