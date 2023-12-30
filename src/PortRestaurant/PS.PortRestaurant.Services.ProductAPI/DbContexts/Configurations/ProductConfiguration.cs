using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.PortRestaurant.Services.ProductAPI.Models;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .HasOne(x => x.Category)
               .WithMany(x => x.Products);
        }
    }
}