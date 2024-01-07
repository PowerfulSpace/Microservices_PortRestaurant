using AutoMapper;
using PS.PortRestaurant.Services.ProductAPI.Models;
using PS.PortRestaurant.Services.ProductAPI.Models.Dto;

namespace PS.PortRestaurant.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();

                config.CreateMap<Category, CategoryDto>();
                config.CreateMap<CategoryDto, Category>();
            });

            return mappingConfig;
        }
    }
}
