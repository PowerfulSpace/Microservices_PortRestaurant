using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var response = await _productService.GetAllProductsAsync<ResponseDto>();

            if(response.Result != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
                
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            await PopulateViewBagsAsync();

            return View();
        }



        private async Task PopulateViewBagsAsync()
        {
            ViewBag.Categories = await GetCategoriesAsync();
        }

        //Врменнно тестовые данные
        private async Task<List<SelectListItem>> GetCategoriesAsync()
        {
            List<SelectListItem> listIItems = new List<SelectListItem>();

            listIItems.Add(new SelectListItem() { Text = "Entree", Value = "11513685-6851-4D54-9AED-4713C84BCC3F" });
            listIItems.Add(new SelectListItem() { Text = "Dessert", Value = "84F69823-BC64-4EF6-A5AE-BE49D3E966F9" });
            listIItems.Add(new SelectListItem() { Text = "Appetizer", Value = "BAEE70CA-5651-4713-82AC-F4442D317AFA" });

            SelectListItem defItem = new SelectListItem()
            {
                Text = "---Select Movie---",
                Value = ""
            };

            listIItems.Insert(0, defItem);
            return listIItems;
        }

    }
}
