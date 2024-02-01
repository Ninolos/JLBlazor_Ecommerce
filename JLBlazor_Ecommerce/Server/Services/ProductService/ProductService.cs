using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;
using static System.Net.WebRequestMethods;

namespace JLBlazor_Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext context)
        {
            _dataContext = context;
        }

        public Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = _dataContext.Products.Find(productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not exist.";    
            }
            else
            {
                response.Data = product;
            }

            return Task.FromResult(response);
        }

        public Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = _dataContext.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToList()
            };

             return Task.FromResult(response);
        }

        public Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>> 
            { 
                Data = _dataContext.Products.ToList(),
            };

            return Task.FromResult(response);
        }
       
    }
}
