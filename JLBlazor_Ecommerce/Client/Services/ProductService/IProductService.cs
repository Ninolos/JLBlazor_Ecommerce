using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSuggestions(string searchText);
    }
}
