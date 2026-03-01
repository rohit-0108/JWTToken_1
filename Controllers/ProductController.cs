using JWTToken_1.Model;
using JWTToken_1.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTToken_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var createdProduct = await _productService.CreateProduct(product);
            return Ok(createdProduct);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var updatedProduct = await _productService.UpdateProduct(product);
            if (updatedProduct == null)
                return NotFound();
            return Ok(updatedProduct);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (!result)
                return NotFound();
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
