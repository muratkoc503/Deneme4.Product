using Microsoft.EntityFrameworkCore;
using Deneme4.Product.Models;
using Deneme4.Product.Repositories.Interfaces;
using Deneme4.Product.Data;

namespace Deneme4.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<Products> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> Update(Products  product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
                return false; 

            _context.Entry(existingProduct).CurrentValues.SetValues(product);

            await _context.SaveChangesAsync();
            return true; 
        }
    }
}
