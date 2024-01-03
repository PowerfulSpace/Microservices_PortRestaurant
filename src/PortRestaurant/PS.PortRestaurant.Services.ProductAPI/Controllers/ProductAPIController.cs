using Microsoft.AspNetCore.Mvc;

namespace PS.PortRestaurant.Services.ProductAPI.Controllers
{
    public class ProductAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
