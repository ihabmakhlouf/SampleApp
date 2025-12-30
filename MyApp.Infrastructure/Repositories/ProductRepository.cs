using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
    {
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
        {
        public async Task<Product> AddProductAsync(Product product)
            {
                product.Id = Guid.NewGuid();
                dbContext.Add(product);
                await dbContext.SaveChangesAsync();
                return product;
            }

        public async Task<Product> GetProductByIdAsync(Guid id)
            {
               return await dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            }

        public async Task<IEnumerable<Product>> GetProductsAsync()
            {
                return await dbContext.products.ToListAsync();
            }
        }
    }
