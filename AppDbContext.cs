using System.Data.Entity;
using ShopProductManagerApp.Model;

namespace ShopProductManagerApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ShopDB")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}