using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using stock_app.Interfaces;
using stock_app.Models;
using stock_app.Models.Databases;
using stock_app.Models.Entities;
using System.Net;

namespace stock_app.Facades
{
    public class ProductsFacade : IProductsFacade
    {
        private const string PRODUCT_CREATED = "Product created.";
        private const string PRODUCTS_RETRIEVED = "Products retrieved.";
        private const string PRODUCT_DELETED = "Product deleted.";
        private const string PRODUCT_UPDATED = "Product updated.";
        private readonly StockContext _stockContext;
        private readonly ILogger _logger;

        public ProductsFacade(StockContext stockContext)
        {
            //_logger = logger;
            _stockContext = stockContext;
        }

        public async Task<ResponseModel> GetProductsAsync()
        {
            return new ResponseModel()
            {
                Status = HttpStatusCode.OK,
                Message = PRODUCTS_RETRIEVED,
                Data = _stockContext.Products
            };
        }
        public async Task<ResponseModel> PostProductAsync(Product product)
        {
            var response = _stockContext.Products.Add(product);

            if (response.State.Equals(EntityState.Added))
            {
                await _stockContext.SaveChangesAsync();
                return new ResponseModel()
                {
                    Status = HttpStatusCode.Created,
                    Message = PRODUCT_CREATED,
                    Data = product
                };
            }

            throw new System.Exception();
        }

        public async Task<ResponseModel> UpdateProductAsync(int id, Product product)
        {

            if (id == product.Id)
            {

                _stockContext.Entry<Product>(product).State = EntityState.Modified;
                await _stockContext.SaveChangesAsync();
                return new ResponseModel()
                {
                    Status = HttpStatusCode.OK,
                    Message = PRODUCT_UPDATED,
                    Data = product
                };
            }

            throw new System.Exception();


        }

        public async Task<ResponseModel> DeleteProductAsync(int id)
        {

            var product = await _stockContext.Products.FindAsync(id);
            _stockContext.Remove(product);
            await _stockContext.SaveChangesAsync();

            return new ResponseModel()
            {
                Status = HttpStatusCode.OK,
                Message = PRODUCT_DELETED,
                Data = product
            };

        }

    }
}