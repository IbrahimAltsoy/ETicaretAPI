
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Buraya dikkat son anda yorum satıra alındı.
        //[HttpGet]
        //public IActionResult GetProducts()
        //{

        //    return Ok();
        //}
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(), Name="Product 7", Price=100, CreatedDate=DateTime.UtcNow, Stock=25},
                new(){Id=Guid.NewGuid(), Name="Product 8", Price=200, CreatedDate=DateTime.UtcNow, Stock=107},
                new(){Id=Guid.NewGuid(), Name="Product 9", Price=430, CreatedDate=DateTime.UtcNow, Stock=185},
            });
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
