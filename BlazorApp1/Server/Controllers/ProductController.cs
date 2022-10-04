using BlazorApp1.Server.Database;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase


    {
         ProductServices service;
        public ProductController()
        {

            service = new ProductServices();
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {

            return await service.GetProductAsync();
        }
        [HttpGet("{id}")]
        public async Task<Product> GetOne(int id)
        {
            Product p = new Product();
            p.Id = id;
            return await service.GetProductAsync(p);
        }

        [HttpPost]
        public async Task<Product> save(Product productToSave)
        {
            
            return await service.AddProductAsync(productToSave);
        }

        [HttpPut]
        public async Task<Product> update(Product productToSave)
        {

            return await service.UpdateProductAsync(productToSave);
        }

        [HttpDelete("{id}")]
        public async void delete(int id)
        {
            Product p = new Product();
            p.Id = id;
            p = await service.GetProductAsync(p);

            await service.DeleteProductAsync(p);
        }
    }
}
