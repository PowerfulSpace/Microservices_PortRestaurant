using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS.PortRestaurant.Services.ProductAPI.DbContexts;
using PS.PortRestaurant.Services.ProductAPI.Models;
using PS.PortRestaurant.Services.ProductAPI.Models.Dto;

namespace PS.PortRestaurant.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }


        public async Task<ProductDto> GetProductById(Guid id)
        {
            Product product = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }
  

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

      
    }
}
