namespace PS.PortRestaurant.Web.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
