using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models.Genre;
using System.Data;

namespace Movie.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly DBContextApplication _db;

        public GenreController(DBContextApplication db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var genre = from m in _db.Genres select m;
            return View(genre.ToList());
        }

        [HttpGet("/Genre/Create")]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Genre obj)
        {
            if(ModelState.IsValid)
            {
                _db.Genres.Add(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Create successfully";

                return RedirectToAction("Index","Genre");
            }

            return View();
        }

        [HttpGet("/Genre/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id) 
        {
            var genre = await _db.Genres.FindAsync(id);
            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre obj)
        {
            if(ModelState.IsValid)
            {
                _db.Genres.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Updated successful";

                return RedirectToAction("Index");
            }
            TempData["error"] = "Process error";
            return View();
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            Genre? genre = _db.Genres.Find(id);
            if(genre == null)
            {
                return View("Error");
            }
            _db.Genres.Remove(genre);
            await _db.SaveChangesAsync();
            TempData["success"] = $"Deleted genre {genre.Name}";

            return RedirectToAction("Index");
        }
    }
}
