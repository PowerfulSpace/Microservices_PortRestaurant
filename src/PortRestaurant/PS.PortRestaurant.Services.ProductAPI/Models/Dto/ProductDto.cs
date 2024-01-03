﻿namespace PS.PortRestaurant.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
