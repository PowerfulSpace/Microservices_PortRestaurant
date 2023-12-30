using Microsoft.EntityFrameworkCore;
using PS.PortRestaurant.Services.ProductAPI.DbContexts.Configurations;
using PS.PortRestaurant.Services.ProductAPI.Models;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
