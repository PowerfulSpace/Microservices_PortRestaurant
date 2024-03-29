﻿using AutoMapper;
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
            Product product = _mapper.Map<ProductDto,Product>(productDto);

            if (product.Id != Guid.Empty)
            {
                _db.Products.Update(product);
            }
            else
            {
                await _db.Products.AddAsync(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }


        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null) { return false; }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

      
    }
}
