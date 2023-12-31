using ClassLibrary.Models;
using ClassLibrary.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories.Products;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productRepo;

        public ProductController(IProduct productRepo)
        {
            this.productRepo = productRepo;
        }

        //api/product/all
        [HttpGet("all")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productRepo.GetProducts();
            if (products == null) return NotFound();
            return Ok(products);
        }

        //api/product/single/id
        [HttpGet("single/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productRepo.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        //api/product/add
        [HttpPost("add")]
        public async Task<ActionResult<GeneralResponse>> AddProduct(Product product)
        {
            var response = await productRepo.AddProduct(product);
            return Ok(response);
        }

        //api/product/single/id
        [HttpPut("update")]
        public async Task<ActionResult<GeneralResponse>> UpdateProduct(Product product)
        {
            var response = await productRepo.UpdateProduct(product);
            return Ok(response);
        }

        //api/product/single/id
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<GeneralResponse>> DeleteProduct(int id)
        {
            var response = await productRepo.DeleteProduct(id);
            return Ok(response);
        }
    }
}
