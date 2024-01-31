using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public  Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var response = new ServiceResponse<List<Category>>
            {
                Data = _context.Categories.ToList(),
            };

            return Task.FromResult(response);
        }

        public Task<ServiceResponse<Category>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
