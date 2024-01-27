using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;
using System.Net.Http.Json;

namespace JLBlazor_Ecommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public async Task GetProduct()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");

            if (result != null && result.Data != null) 
            {
                Products = result.Data;
            }
        }
    }
}
