﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.PortRestaurant.Services.ProductAPI.Models;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Category);               
        }
    }
}
