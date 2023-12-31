using ClassLibrary.Models;
using ClassLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Repositories.Products
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext server;

        public ProductRepo(AppDbContext server)
        {
            this.server = server;
        }
        public async Task<GeneralResponse> AddProduct(Product product)
        {
            server.Products.Add(product);
            await server.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully added");
        }

        public async Task<GeneralResponse> DeleteProduct(int id)
        {
            var product = await server.Products.FindAsync(id);
            server.Products.Remove(product!);
            await server.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully updated");
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await server.Products.FindAsync(id);
            return product!;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await server.Products.ToListAsync();
            return products!;
        }

        public async Task<GeneralResponse> UpdateProduct(Product product)
        {
            server.Products.Update(product);
            await server.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully deleted");
        }
    }
}
