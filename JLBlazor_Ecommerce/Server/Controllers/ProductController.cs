using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace JLBlazor_Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public ActionResult<List<Product>> GetProduct()
        {

            var teste = _dataContext.Products;
            if (_dataContext.Products != null)
            {
                var products = _dataContext.Products.ToList();

                return Ok(products);
            }
            else
            {                
                return NotFound("A coleção de produtos é nula.");
            }
        }

    }
}
