using System.ComponentModel.DataAnnotations;

namespace PS.PortRestaurant.Services.ProductAPI.Models
{
    public class Category
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
