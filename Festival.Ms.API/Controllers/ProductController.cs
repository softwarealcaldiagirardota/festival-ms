using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_productService.GetProduct(id)));
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
    }
}
