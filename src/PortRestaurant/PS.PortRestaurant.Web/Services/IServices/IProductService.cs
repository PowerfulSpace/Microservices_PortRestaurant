using PS.PortRestaurant.Web.Models.Dto;

namespace PS.PortRestaurant.Web.Services.IServices
{
    public interface IProductService
    {
        public Task<T> GetAllProductsAsync<T>();
        public Task<T> GetProductAsync<T>(Guid id);
        public Task<T> CreateProductAsync<T>(ProductDto productDto);
        public Task<T> UpdateProductAsync<T>(ProductDto productDto);
        public Task<T> DeleteProductAsync<T>(Guid id);
    }
}
