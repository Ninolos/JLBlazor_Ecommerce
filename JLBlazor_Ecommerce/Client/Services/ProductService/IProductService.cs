using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProduct();
    }
}
