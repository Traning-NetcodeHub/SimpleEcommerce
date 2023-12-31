using ClassLibrary.Models;
using ClassLibrary.Responses;
namespace WebAPI.Repositories.Products
{
    public interface IProduct
    {
        Task<GeneralResponse> AddProduct(Product product);
        Task<GeneralResponse> UpdateProduct(Product product);
        Task<GeneralResponse> DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProducts();
    }
}
