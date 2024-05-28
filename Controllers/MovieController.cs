using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Data;
using Movie.Models.Cast;
using Movie.Models.Company;
using Movie.Models.Genre;
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

        public MovieViewModel GetDataSelectlist()
        {
            var cast = from m in _db.Cast select m;
            var genre = from m in _db.Genres select m;
            var company = from m in _db.Companys select m;

            var model = new MovieViewModel
            {
                MovieCaster = new List<SelectListItem>(),
                MovieGenre = new List<SelectListItem>(),
                MovieCompany = new List<SelectListItem>(),
            };

            foreach (var item in cast.ToList())
            {
                model.MovieCaster.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            foreach (var item in genre.ToList())
            {
                model.MovieGenre.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            foreach (var item in company.ToList())
            {
                model.MovieCompany.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            return model;
        }

        public IActionResult Create()
        {
            var model = GetDataSelectlist();
            return View(model);
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
                await _db.SaveChangesAsync();

                //Get next id of Movies
                var nextMovieId = movie.Id;
                var movieCast = new MovieCast
                {
                    MovieId = nextMovieId,
                    CastId = request.CastId,
                };

                var movieGenre = new MovieGenre
                {
                    MovieId = nextMovieId,
                    GenreId = request.GenreId,
                };

                var movieCompany = new MovieCompany
                {
                    MovieId = nextMovieId,
                    CompanyId = request.CompanyId,
                };

                _db.MovieCasts.Add(movieCast);
                _db.MovieGenres.Add(movieGenre);
                _db.Movies.Add(movie);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        public string UploadFile(MovieViewModel request)
        {
            string file = null;
            if (request.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/movies/");
                file = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
                var filePath = Path.Combine(uploadDir, file);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
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
            var newMovie = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Viewed = movie.Viewed,
                Movie_Status = movie.Movie_Status,
                MovieCaster = GetDataSelectlist().MovieCaster,
                MovieGenre = GetDataSelectlist().MovieGenre,
                MovieCompany = GetDataSelectlist().MovieCompany,
            };
            return View(newMovie);
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
                if (request.Image == null)
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
