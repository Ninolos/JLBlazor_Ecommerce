using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
