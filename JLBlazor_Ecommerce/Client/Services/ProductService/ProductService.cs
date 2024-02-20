using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.DTOs;
using JLBlazor_Ecommerce.Shared.Models;
using System.Net.Http.Json;

namespace JLBlazor_Ecommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; } = new Product();
        public string Message { get; set; } = "Loading...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") 
                                             : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/category/{categoryUrl}");

            if (result != null && result.Data != null) 
            {
                Products = result.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0) 
            {
                Message = "Products Not Found";
            }

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");

            return result;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/Product/search/{searchText}/{page}");

            if (result != null && result.Data != null ) 
            { 
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }

            if (Products.Count == 0)
            {
                Message = "No Products";
            }

            ProductsChanged.Invoke();
            
        }

        public async Task<List<string>> GetProductSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggestions/{searchText}");                       

            return result.Data;
        }
    }
}
