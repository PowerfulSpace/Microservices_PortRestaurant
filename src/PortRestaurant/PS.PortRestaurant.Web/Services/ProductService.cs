﻿using PS.PortRestaurant.Web.Models;
using PS.PortRestaurant.Web.Models.Dto;
using PS.PortRestaurant.Web.Services.IServices;

namespace PS.PortRestaurant.Web.Services
{
    public class ProductService : BaseService,IProductService
    {
        public ResponseDto ResponseModel { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsyncAsync<T>(Guid id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "api/ProductAPI/" + id,
                AccessToken = ""
            });
        }



        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(Guid id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "api/ProductAPI/" + id,
                AccessToken = ""
            });
        }
    }
}
