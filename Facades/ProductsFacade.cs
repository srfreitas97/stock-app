using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using stock_app.Interfaces;
using stock_app.Models;
using stock_app.Models.Databases;
using stock_app.Models.Entities;
using stock_app.Exceptions;
using Microsoft.AspNetCore.Http;

namespace stock_app.Facades
{
    public class ProductsFacade : IProductsFacade
    {
        private const string PRODUCT_CREATED = "Product created.";
        private const string PRODUCTS_RETRIEVED = "Products retrieved.";
        private const string PRODUCT_DELETED = "Product deleted.";
        private const string PRODUCT_UPDATED = "Product updated.";
        private const string VALIDATION_MESSAGE = "Id passed as parameter doesn't match product id.";
        private const string DATABASE_ERROR_MESSAGE = "Error ocurred while adding product to the database.";
        private const string PRODUCT_NOT_FOUND_MESSAGE = "Product not found for the given id.";
        private readonly StockContext _stockContext;
        private readonly ILogger _logger;

        public ProductsFacade(StockContext stockContext, ILogger<ProductsFacade> logger)
        {
            _logger = logger;
            _stockContext = stockContext;
        }

        public async Task<ResponseModel> GetProductsAsync()
        {
            return new ResponseModel()
            {
                Status = StatusCodes.Status200OK,
                Message = PRODUCTS_RETRIEVED,
                Data = _stockContext.Products
            };
        }
        public async Task<ResponseModel> PostProductAsync(Product product)
        {
            var response = _stockContext.Products.Add(product);

            await _stockContext.SaveChangesAsync();
            return new ResponseModel()
            {
                Status = StatusCodes.Status201Created,
                Message = PRODUCT_CREATED,
                Data = product
            };


        }

        public async Task<ResponseModel> UpdateProductAsync(int id, Product product)
        {
            if (id == product.Id)
            {

                _stockContext.Entry<Product>(product).State = EntityState.Modified;
                await _stockContext.SaveChangesAsync();
                return new ResponseModel()
                {
                    Status = StatusCodes.Status200OK,
                    Message = PRODUCT_UPDATED,
                    Data = product
                };

            }
            else
            {
                throw new BadRequestException(VALIDATION_MESSAGE);
            }

        }

        public async Task<ResponseModel> DeleteProductAsync(int id)
        {

            var product = await _stockContext.Products.FindAsync(id);
            if (product != null)
            {
                _stockContext.Remove(product);
                await _stockContext.SaveChangesAsync();

                return new ResponseModel()
                {
                    Status = StatusCodes.Status200OK,
                    Message = PRODUCT_DELETED,
                    Data = product
                };
            }
            else
            {
                throw new ProductNotFoundException(PRODUCT_NOT_FOUND_MESSAGE, id);
            }

        }

    }
}