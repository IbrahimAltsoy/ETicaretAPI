
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       

        [HttpGet]
        public IActionResult GetProducts()
        {
            
            return Ok();
        }
    }
}
