using JLBlazor_Ecommerce.Shared.Models;
using JLBlazor_Ecommerce.Shared;

namespace JLBlazor_Ecommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetCategories();
        //Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
