using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models.Cast;
using Movie.Models.Movie;

namespace Movie.Controllers
{
    public class CastController : Controller
    {
        private readonly DBContextApplication _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CastController(DBContextApplication db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var cast = from m in _db.Cast select m;
            return View(cast.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CastViewModel request)
        {
            if (ModelState.IsValid)
            {
                    string fileName = UploadFile(request);
                    Cast cast = new Cast
                    {
                        Name = request.Name,
                        ProfileImage = fileName
                    };

                    _db.Cast.Add(cast);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var cast = await _db.Cast.FindAsync(id);
            return View(cast);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CastViewModel request)
        {
            if (ModelState.IsValid)
            {
                Cast cast = new Cast
                {
                    Id = request.Id,
                    Name = request.Name,
                };

                //keep old image if it not changes
                if (request.ProfileImage == null)
                {
                    var mv = from m in _db.Movies.Where(p => p.Id == cast.Id) select m.Image;
                    cast.ProfileImage = mv.ToArray().First();
                }
                else
                {
                    cast.ProfileImage = UploadFile(request);
                }

                _db.Cast.Update(cast);
                await _db.SaveChangesAsync();

                TempData["success"] = $"Updated {request.Name}";

                return RedirectToAction("Index");
            }
            return View();
        }

        public string UploadFile(CastViewModel request)
        {
            string file = null;
            if (request.ProfileImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/cast/");
                file = Guid.NewGuid().ToString() + "-" + request.ProfileImage.FileName;
                var filePath = Path.Combine(uploadDir, file);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    request.ProfileImage.CopyTo(fileStream);
                }
            }

            return file;
        }
    }
}
