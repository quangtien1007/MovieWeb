using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models.Company;
using Movie.Models.Genre;

namespace Movie.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DBContextApplication _db;

        public CompanyController(DBContextApplication db) {
            _db = db;
        }
        public IActionResult Index()
        {
            var company = from m in _db.Companys select m;
            return View(company.ToList());
        }

        [HttpGet("/Company/Create")]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Company obj)
        {
            if (ModelState.IsValid)
            {
                _db.Companys.Add(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Create successfully";

                return RedirectToAction("Index", "Company");
            }

            return View();
        }

        [HttpGet("/Company/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var company = await _db.Companys.FindAsync(id);
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company obj)
        {
            if (ModelState.IsValid)
            {
                _db.Companys.Update(obj);
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
            Company? company = _db.Companys.Find(id);
            if (company == null)
            {
                return View("Error");
            }
            _db.Companys.Remove(company);
            await _db.SaveChangesAsync();
            TempData["success"] = $"Deleted genre {company.Name}";

            return RedirectToAction("Index");
        }
    }
}
