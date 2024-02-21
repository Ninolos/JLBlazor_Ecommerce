using JLBlazor_Ecommerce.Server.Services.CartService;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.DTOs;
using JLBlazor_Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JLBlazor_Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public ActionResult<ServiceResponse<List<CartProductResponse>>> GetCartProducts([FromBody] List<CartItem> cartItems)
        {
            var result = _cartService.GetCartProducts(cartItems);

            return Ok(result);
        }
    }
}
