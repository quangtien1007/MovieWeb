using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContextApplication _db;

        public HomeController(DBContextApplication db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   
            var movie = from m in _db.Movies select m;
            if (User.IsInRole("Admin"))
            {
                return View("Admin");
            }
            else
            {
                return View(movie.ToList());
            }
        }

        public async Task<ActionResult> Privacy()
        {
            List<MovieDBViewModel.MovieData> reservationList = new List<MovieDBViewModel.MovieData>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync("users");
                if(response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    reservationList = JsonConvert.DeserializeObject<List<MovieDBViewModel.MovieData>>(data);
                }
            }
            return View(reservationList.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}