using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models.Movie;


namespace Movie.Controllers
{
    public class MovieController : Controller
    {
        private readonly DBContextApplication _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(DBContextApplication db, IWebHostEnvironment webHostEnvironment) {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var movie = from m in _db.Movies select m;
            return View(movie.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movies obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Image != null) { 
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + obj.Image.FileName;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await obj.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); 
                }

                _db.Movies.Add(obj);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
