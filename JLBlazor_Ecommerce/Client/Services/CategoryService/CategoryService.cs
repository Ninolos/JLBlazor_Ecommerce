using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;
using System.Net.Http.Json;

namespace JLBlazor_Ecommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public Category Category { get; set; } = new Category();

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");

            if (result != null && result.Data != null)
            {
                Categories = result.Data;
            }
        }
    }
}
