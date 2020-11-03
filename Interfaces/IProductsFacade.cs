using System.Threading.Tasks;
using stock_app.Models;
using stock_app.Models.Entities;

namespace stock_app.Interfaces
{
    public interface IProductsFacade
    {
        Task<ResponseModel> GetProductsAsync();
        Task<ResponseModel> PostProductAsync(Product product);
        Task<ResponseModel> UpdateProductAsync(int id, Product product);
        Task<ResponseModel> DeleteProductAsync(int id);
    }
}