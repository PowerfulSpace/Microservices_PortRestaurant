using PS.PortRestaurant.Web.Models.Dto;

namespace PS.PortRestaurant.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        public Task<T> GetAllProductsAsync<T>();
        public Task<T> GetProductByIdAsyncAsync<T>(Guid id);
        public Task<T> CreateProductAsync<T>(ProductDto productDto);
        public Task<T> UpdateProductAsync<T>(ProductDto productDto);
        public Task<T> DeleteProductAsync<T>(Guid id);
    }
}
