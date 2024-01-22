using PS.PortRestaurant.Web.Models.Dto;

namespace PS.PortRestaurant.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        public Task<T> GetAllProductsAsync<T>(string token);
        public Task<T> GetProductByIdAsyncAsync<T>(Guid id, string token);
        public Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        public Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        public Task<T> DeleteProductAsync<T>(Guid id, string token);
    }
}
