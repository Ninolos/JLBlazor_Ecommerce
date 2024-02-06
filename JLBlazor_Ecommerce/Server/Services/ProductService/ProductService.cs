using JLBlazor_Ecommerce.Server.Data;
using JLBlazor_Ecommerce.Shared;
using JLBlazor_Ecommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using static System.Net.WebRequestMethods;

namespace JLBlazor_Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext context)
        {
            _dataContext = context;
        }

        public Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();           

            var product = _dataContext.Products
                    .Where(p => p.Id == productId)
                    .Select(p => new
                    {
                        Product = p,
                        Variants = p.Variants.Select(v => new
                        {
                            Variant = v,
                            ProductType = v.ProductType,
                        })
                    })
                    .FirstOrDefault();

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not exist.";
            }
            else
            {                
                response.Data = product.Product;
            }

            return Task.FromResult(response);
        }

        public Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>();

            var products = _dataContext.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToList();

            foreach (Product product in products)
            {
                _dataContext.Entry(product)
                                .Collection(p => p.Variants)
                                .LoadAsync();
            }

            response.Data = products;

            return Task.FromResult(response);
        }

        public Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>>();
            
            var products = _dataContext.Products.ToList();

            foreach (Product product in products)
            {               
                _dataContext.Entry(product)
                                .Collection(p => p.Variants)
                                .LoadAsync();
            }

            response.Data = products;

            return Task.FromResult(response);
        }
       
    }
}
