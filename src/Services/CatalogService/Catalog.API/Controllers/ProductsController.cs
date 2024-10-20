using Catalog.API.Entities;
using Catalog.API.Models;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductModel createProductModel)
        {
            await _productService.CreateProductAsync(createProductModel);
            return Ok("Product created");
        }
    }
}
