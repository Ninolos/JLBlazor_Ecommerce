using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.DTOs;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _dataContext;
        public CartService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>
            {
                Data = new List<CartProductResponse>()
            };


        }
    }
}
