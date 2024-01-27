using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext context)
        {
            _dataContext = context;
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
