using Microsoft.EntityFrameworkCore;
using PS.PortRestaurant.Services.ProductAPI.DbContexts.Configurations;
using PS.PortRestaurant.Services.ProductAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


            var category1 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Appetizer"
            };
            var category2 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Dessert"
            };
            var category3 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Entree"
            };


            var product1 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samosa",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://e1.edimdoma.ru/data/posts/0002/2542/22542-ed4_wide.jpg?1631192811",
                CategoryId = category1.Id
            };
            var product2 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Paneer Tikka",
                Price = 13.99m,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://img-global.cpcdn.com/recipes/251da7cdca421f817701a5467edd095a73e9f43f6fe624825fc8fcd17bc9304f/680x482cq70/ghoriachiie-bliuda-na-novyi-ghod-%D0%BE%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D0%BE%D0%B5-%D1%84%D0%BE%D1%82%D0%BE-%D1%80%D0%B5%D1%86%D0%B5%D0%BF%D1%82%D0%B0.jpg",
                CategoryId = category1.Id
            };
            var product3 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sweet Pie",
                Price = 10.99m,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://s1.webspoon.ru/receipts/2021/1/41606/orig_41606_0_xxl.jpg",
                CategoryId = category2.Id
            };
            var product4 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Pav Bhaji",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RMcFUJhD35yfT4Ps2HR16l8fBY85dqcDcg&usqp=CAU",
                CategoryId = category3.Id
            };


            modelBuilder.Entity<Category>().HasData(category1, category2, category3);
            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);

            base.OnModelCreating(modelBuilder);

        }

    }
}
