using JLBlazor_Ecommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JLBlazor_Ecommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
