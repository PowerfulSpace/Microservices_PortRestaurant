using Microsoft.AspNetCore.Mvc;

namespace PS.PortRestaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
