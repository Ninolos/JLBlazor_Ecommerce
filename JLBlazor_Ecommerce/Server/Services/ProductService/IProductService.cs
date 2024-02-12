﻿using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
        Task<ServiceResponse<Product>> GetProductAsync(int  productId);
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchText);
    }
}
