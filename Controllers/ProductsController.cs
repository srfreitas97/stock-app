using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stock_app.Models.Entities;
using stock_app.Models.Databases;
using stock_app.Interfaces;

namespace stock_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsFacade _productsFacade;
        private readonly StockContext _stockContext;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, StockContext stockContext, IProductsFacade productsFacade)
        {
            _logger = logger;
            _stockContext = stockContext;
            _productsFacade = productsFacade;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            return CreatedAtAction(nameof(PostProduct), await _productsFacade.PostProductAsync(product));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productsFacade.GetProductsAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts([FromRoute] int id,[FromBody] Product product)
        {
            return Ok(await _productsFacade.UpdateProductAsync(id, product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            return Ok(await _productsFacade.DeleteProductAsync(id));
        }
    }
}
