using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
