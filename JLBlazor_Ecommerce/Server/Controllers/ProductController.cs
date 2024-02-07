using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Server.Services.ProductService;
using JLBlazor_Ecommerce.Shared;
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
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<ServiceResponse<List<Product>>> GetProduct()
        {           
            var products = _productService.GetProducts();

            if (products.Result.Data.Any())
            {
                return Ok(products.Result);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ServiceResponse<Product>> GetProductById(int id)
        {
            var products = _productService.GetProductAsync(id);

            if (products.Result.Data != null)
            {
                return Ok(products.Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public ActionResult<ServiceResponse<Product>> GetProductByCategory(string categoryUrl)
        {
            var products = _productService.GetProductByCategory(categoryUrl);

            if (products.Result.Data != null)
            {
                return Ok(products.Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("search/{searchText}")]
        public ActionResult<ServiceResponse<Product>> SearchProducts(string searchText)
        {
            var products = _productService.SearchProducts(searchText);

            if (products.Result.Data != null)
            {
                return Ok(products.Result);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
