using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PS.PortRestaurant.Web.Models.Dto;
using PS.PortRestaurant.Web.Services.IServices;

namespace PS.PortRestaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);

            if(response.Result != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
                
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProductAsync<ResponseDto>(model, accessToken);

                if (response.Result != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }

            return View(model);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> ProductEdit(Guid productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsyncAsync<ResponseDto>(productId, accessToken);

            if (response.Result != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProductAsync<ResponseDto>(model, accessToken);

                if (response.Result != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(Guid productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsyncAsync<ResponseDto>(productId, accessToken);

            if (response.Result != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.DeleteProductAsync<ResponseDto>(model.Id, accessToken);

                if (response.Result != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }

            return View(model);
        }
    }
}
