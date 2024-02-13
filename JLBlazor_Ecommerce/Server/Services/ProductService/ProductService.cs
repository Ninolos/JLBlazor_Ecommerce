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
                product.Variants = _dataContext.ProductVariants
                                    .Where(v => v.ProductId == product.Id)
                                    .ToList();
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
                product.Variants = _dataContext.ProductVariants
                                    .Where(v => v.ProductId == product.Id)
                                    .ToList();
            }

            response.Data = products;

            return Task.FromResult(response);
        }
        public Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            return FindProductsSearchText(searchText);
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();

            response = await FindProductsSearchText(searchText);

            var products = response.Data;

            List<string> suggestions = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    suggestions.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var ponctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(s => s.Trim(ponctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !suggestions.Contains(word))
                        {
                            suggestions.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = suggestions };
        }

        private Task<ServiceResponse<List<Product>>> FindProductsSearchText(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();

            var products = _dataContext.Products
                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower())).ToList();

            foreach (Product product in products)
            {
                product.Variants = _dataContext.ProductVariants
                    .Where(v => v.ProductId == product.Id).ToList();
            }

            response.Data = products;

            return Task.FromResult(response);
        }

        public Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>();

            var products = _dataContext.Products.Where(p => p.Featured).ToList();

            foreach (Product product in products)
            {
                product.Variants = _dataContext.ProductVariants
                                    .Where(v => v.ProductId == product.Id)
                                    .ToList();
            }

            response.Data = products;

            return Task.FromResult(response);
        }
    }
}
