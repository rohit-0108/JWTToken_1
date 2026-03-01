using JWTToken_1.Model;
using JWTToken_1.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace JWTToken_1.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<bool> DeleteProduct(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
                return false;
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            return prod;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var existprod = await _context.Products.FindAsync(product.Id);
            if (existprod == null)
                return null;
            existprod.Name = product.Name;
            existprod.Price = product.Price;
            _context.Products.Update(existprod);
            await _context.SaveChangesAsync();
            return existprod;
        }
    }
}
