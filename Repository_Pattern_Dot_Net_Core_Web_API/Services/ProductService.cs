using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Repository_Pattern_Dot_Net_Core_Web_API.Data;
using Repository_Pattern_Dot_Net_Core_Web_API.Models;
using Repository_Pattern_Dot_Net_Core_Web_API.Models.DTO;
using Repository_Pattern_Dot_Net_Core_Web_API.Models.Repository;

namespace Repository_Pattern_Dot_Net_Core_Web_API.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProduct(string productId)
        {
            var product = await _context.Products.FindAsync(new Guid(productId));

            if (product != null)
            {
                return product;
            }
            throw new KeyNotFoundException("Product not found.");
        }

        public async Task DeleteProduct(string productId)
        {
            var product = await _context.Products.FindAsync(new Guid(productId));

            if (product != null)
            {
                 _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            throw new KeyNotFoundException("Product not found.");
        }

        public async Task<Product> UpdateProduct(string productId, Product product)
        {
            var item = await _context.Products.FindAsync(new Guid(productId));

            if(item != null)
            {
                item.Name = product.Name;
                item.Description = product.Description;
                item.Price = product.Price;

                await _context.SaveChangesAsync();
                return item;
            }
            throw new KeyNotFoundException("Product not found.");
        }

        public async Task<Product> PatchProduct(string productId, JsonPatchDocument<Product> patchProduct)
        {
            var item = await _context.Products.FindAsync(new Guid(productId));

            if (item != null)
            {
                patchProduct.ApplyTo(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new KeyNotFoundException("Product Not Found");
        }
    }
}
