using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Repository_Pattern_Dot_Net_Core_Web_API.Models.DTO;

namespace Repository_Pattern_Dot_Net_Core_Web_API.Models.Repository
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> AddProduct(Product product);
        
        Task<Product> UpdateProduct(string productId, Product product);
        Task<Product> PatchProduct(string productId, JsonPatchDocument<Product> product);

        Task<Product> GetProduct(string productId);

        Task DeleteProduct(string productId);
    }
}
