using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
    {
    public interface IProductRepository
        {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<bool> UpdateProductAsync(Product product, Guid id);
        Task<bool> DeleteProductByIdAsync(Guid id);


        }
    }
