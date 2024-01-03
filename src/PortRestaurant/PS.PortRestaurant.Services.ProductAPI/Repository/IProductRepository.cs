using PS.PortRestaurant.Services.ProductAPI.Models.Dto;

namespace PS.PortRestaurant.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(Guid id);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(Guid id);
    }
}
