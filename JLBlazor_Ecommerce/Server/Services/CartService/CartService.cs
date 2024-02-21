using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.DTOs;
using JLBlazor_Ecommerce.Shared.Models;
using System.Data.Entity;

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

            foreach (var cartItem in cartItems)
            {
                var product = _dataContext.Products.Where(p => p.Id == cartItem.ProductId).FirstOrDefault();

                if (product == null)
                {
                    continue;
                }

                var productVariants = _dataContext.ProductVariants.Where(v => v.ProductId == cartItem.ProductId && v.ProductTypeId == cartItem.ProductTypeId).FirstOrDefault();
                

                productVariants.ProductType = _dataContext.ProductTypes.Where(p => p.Id == productVariants.ProductTypeId).FirstOrDefault();

                if (productVariants == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponse
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariants.Price,
                    ProductType = productVariants.ProductType.Name,
                    ProductTypeId = productVariants.ProductTypeId,
                };

                result.Data.Add(cartProduct);
            }
            return Task.FromResult(result);
        }
    }
}
