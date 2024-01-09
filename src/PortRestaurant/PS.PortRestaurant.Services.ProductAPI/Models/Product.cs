using System.ComponentModel.DataAnnotations;

namespace PS.PortRestaurant.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Range(1, 1000)]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;      
        public string ImageUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
