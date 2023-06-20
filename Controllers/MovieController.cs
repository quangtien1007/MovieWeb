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
        public async Task<IActionResult> Create(MovieViewModel request)
        {
            if (ModelState.IsValid)
            {
                string fileName = UploadFile(request);
                var movie = new Movies
                {
                    Title = request!.Title!,
                    ReleaseDate = request.ReleaseDate,
                    Image = UploadFile(request),
                    Overview = request.Overview,
                    Movie_Status = request.Movie_Status,
                };

                _db.Movies.Add(movie);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        public string UploadFile(MovieViewModel request)
        {
            string file = null;
            if(request.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/movies/");
                file = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
                var filePath = Path.Combine(uploadDir, file);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }
            }

            return file;
        }

        [HttpGet("/Movie/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var movie = await _db.Movies.FindAsync(id);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieViewModel request)
        {
            if (ModelState.IsValid)
            {
                Movies movie = new Movies
                {
                    Id = request.Id,
                    Title = request!.Title!,
                    ReleaseDate = request.ReleaseDate,
                    Overview = request.Overview,
                    Movie_Status = request.Movie_Status,
                };

                //keep old image if it not changes
                if(request.Image == null)
                {
                    var mv = from m in _db.Movies.Where(p => p.Id == movie.Id) select m.Image;
                    movie.Image = mv.ToArray().First();
                }
                else
                {
                    movie.Image = UploadFile(request);
                }

                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();

                TempData["success"] = $"Updated {request.Title}";

                return RedirectToAction("Index");
            }

            return View();
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var movie = await _db.Movies.FindAsync(id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();

            TempData["success"] = $"Deleted {movie.Title}";

            return RedirectToAction("Index");
        }
    }
}
