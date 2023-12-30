﻿using Microsoft.EntityFrameworkCore;
using PS.PortRestaurant.Services.ProductAPI.Models;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
