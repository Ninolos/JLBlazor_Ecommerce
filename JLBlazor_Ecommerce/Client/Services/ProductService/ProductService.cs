﻿using JLBlazor_Ecommerce.Shared;
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
        public Product Product { get; set; } = new Product();
        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");

            if (result != null && result.Data != null) 
            {
                Products = result.Data;
            }
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");

            return result;
        }
    }
}
