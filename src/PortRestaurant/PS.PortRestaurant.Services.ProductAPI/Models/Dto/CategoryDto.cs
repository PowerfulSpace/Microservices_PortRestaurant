namespace PS.PortRestaurant.Services.ProductAPI.Models.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
