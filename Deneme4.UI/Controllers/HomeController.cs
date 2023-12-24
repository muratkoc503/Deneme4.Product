using Microsoft.AspNetCore.Mvc;

namespace Deneme4.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
