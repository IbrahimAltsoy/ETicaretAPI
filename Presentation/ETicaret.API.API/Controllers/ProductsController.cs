
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        //readonly private IOrderWriteRepository _orderWriteRepository;
        //readonly private IOrderReadRepository _orderReadRepository;
        //readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository/*, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICustomerWriteRepository customerWriteRepository*/)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            //_orderWriteRepository = orderWriteRepository;
            //_orderReadRepository = orderReadRepository;
            //_customerWriteRepository = customerWriteRepository;
        }
        //[HttpGet]
        //public async Task Get()
        //{
        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new(){Id=Guid.NewGuid(), Name="Product 7", Price=100, CreatedDate=DateTime.UtcNow, Stock=25},
        //    //    new(){Id=Guid.NewGuid(), Name="Product 8", Price=200, CreatedDate=DateTime.UtcNow, Stock=107},
        //    //    new(){Id=Guid.NewGuid(), Name="Product 9", Price=430, CreatedDate=DateTime.UtcNow, Stock=185},
        //    //});
        //    //await _productWriteRepository.SaveAsync();


        //    //Product p = await _productReadRepository.GetByIdAsync("34efdd7d-8940-4542-b759-e48badc533fd");
        //    //p.Name = "Laptop";
        //    //await _productWriteRepository.SaveAsync();
        //    //await _productWriteRepository.AddAsync(new(){Name="IPhene 13", Price=32.700F, Stock=23, CreatedDate=DateTime.UtcNow });
        //    //_productWriteRepository.SaveAsync();

        //    //var customerId = Guid.NewGuid();
        //    // await _customerWriteRepository.AddAsync(new() { Id=customerId, Name="ibrahim"});

        //    // await _orderWriteRepository.AddAsync(new() {Description ="Merhaba", Adress="İstanbul", CustomerId=customerId   });
        //    // await _orderWriteRepository.AddAsync(new() { Description = "Selam", Adress = "Kadiköy", CustomerId = customerId });
        //    // await _orderWriteRepository.SaveAsync();

        //    Order order = await _orderReadRepository.GetByIdAsync("c2d4eeba-823d-43e3-8444-71ac880a2eff");
        //    order.Description = "İstanbul Avcılar";
        //    await _orderWriteRepository.SaveAsync();

        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}   
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));

        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,

            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
