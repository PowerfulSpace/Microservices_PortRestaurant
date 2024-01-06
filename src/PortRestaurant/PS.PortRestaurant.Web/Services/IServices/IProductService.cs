namespace PS.PortRestaurant.Web.Services.IServices
{
    public interface IProductService
    {
        public Task<T> GetAllProductsAsync<T>();
        public Task<T> GetProductAsync<T>(Guid id);
        public Task<T> CreateProductAsync<T>();
        public Task<T> UpdateProductAsync<T>();
        public Task<T> DeleteProductAsync<T>(Guid id);
    }
}
