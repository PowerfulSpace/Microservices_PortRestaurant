using Microsoft.AspNetCore.Mvc;
using PS.PortRestaurant.Services.ProductAPI.Models.Dto;
using PS.PortRestaurant.Services.ProductAPI.Repository;

namespace PS.PortRestaurant.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }
    }
}
