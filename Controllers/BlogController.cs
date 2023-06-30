using Microsoft.AspNetCore.Mvc;
using Movie.Data;

namespace Movie.Controllers
{
    public class BlogController : Controller
    {
        private readonly DBContextApplication _db;

        public BlogController(DBContextApplication db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var blog = from m in _db.Posts select m;
            return View(blog.Take(6).ToList());
        }
    }
}
