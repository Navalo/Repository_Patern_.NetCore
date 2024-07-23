using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern_Dot_Net_Core_Web_API.Models;
using Repository_Pattern_Dot_Net_Core_Web_API.Models.Repository;

namespace Repository_Pattern_Dot_Net_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService IProductService)
        {
            productService = IProductService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productService.GetProducts();
        }

        [HttpPost]
        public async Task<Product> PostProduct([FromBody] Product product)
        {
            return await productService.AddProduct(product);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(string id)
        {
            return await productService.GetProduct(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(string id)
        {
            await productService.DeleteProduct(id);
        }

        [HttpPut("{id}")]
        public async Task<Product> UpdateProduct(string id, [FromBody] Product product)
        {
            return await productService.UpdateProduct(id, product);
        }        
        
        [HttpPatch("{id}")]
        public async Task<Product> PatchProduct(string id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            return await productService.PatchProduct(id, patchDoc);
        }
    }
}
