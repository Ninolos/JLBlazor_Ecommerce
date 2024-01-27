﻿using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;

namespace JLBlazor_Ecommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
    }
}
