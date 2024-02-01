using JLBlazor_Ecommerce.Shared.Models;
using JLBlazor_Ecommerce.Shared;

namespace JLBlazor_Ecommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
        Task<ServiceResponse<Category>> GetCategory(int id);
    }
}
