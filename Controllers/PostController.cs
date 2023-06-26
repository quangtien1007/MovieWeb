using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Data;
using Movie.Models.Cast;
using Movie.Models.Genre;
using Movie.Models.Post;

namespace Movie.Controllers
{
    public class PostController : Controller
    {
        private readonly DBContextApplication _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(DBContextApplication db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var post = from m in _db.Posts select m;
            return View(post.ToList());
        }

        public PostViewModel GetDataSelectlist()
        {
            var cast = from m in _db.Cast select m;
            var genre = from m in _db.Genres select m;

            var model = new PostViewModel
            {
                PostCaster = new List<SelectListItem>(),
                PostGenre = new List<SelectListItem>(),
            };

            foreach (var item in cast.ToList())
            {
                model.PostCaster.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            foreach (var item in genre.ToList())
            {
                model.PostGenre.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            return model;
        }

        public IActionResult Create()
        {
            var model = GetDataSelectlist();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel request)
        {
            if (ModelState.IsValid)
            {
                string fileName = UploadFile(request);
                var post = new Posts
                {
                    Title = request!.Title!,
                    Created = DateTime.Now,
                    Thumbnail = UploadFile(request),
                    Content = request.Content,
                    Status = "Active",
                };

                //Get next id of Posts
                var listId = from i in _db.Posts select i.Id;
                var nextPostId = listId.ToList().Max();

                if (nextPostId == 0)
                {
                    nextPostId = 1;
                }
                else
                {
                    nextPostId++;
                }
                var postCast = new PostCast
                {
                    PostId = nextPostId,
                    CastId = request.CastId,
                };

                var postGenre = new PostGenre
                {
                    PostId = nextPostId,
                    GenreId = request.GenreId,
                };


                _db.PostCasts.Add(postCast);
                _db.PostGenres.Add(postGenre);
                _db.Posts.Add(post);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        public string UploadFile(PostViewModel request)
        {
            string file = null;
            if (request.Thumbnail != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/posts/");
                file = Guid.NewGuid().ToString() + "-" + request.Thumbnail.FileName;
                var filePath = Path.Combine(uploadDir, file);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    request.Thumbnail.CopyTo(fileStream);
                }
            }

            return file;
        }
    }
}
