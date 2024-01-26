using JLBlazor_Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JLBlazor_Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            return Ok(products);
        }

        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Title = "Title Test",
                ImageUrl = "https://img.freepik.com/psd-gratuitas/maquete-de-capa-dura-de-livro_125540-225.jpg?w=1060&t=st=1706211846~exp=1706212446~hmac=18ccff803b39d0e4852f63646f4f5f89e37e172de0593c79a0d22d8536ab4ae2",
                Description = "Desc Test",
                Price = 100,
            }
        };
    }
}
