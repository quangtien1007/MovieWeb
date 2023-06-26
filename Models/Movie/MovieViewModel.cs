using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movie.Models.Movie
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        public string? Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Viewed { get; set; }
        public string? Movie_Status { get; set; }
        public int CastId { get; set; }
        public int CompanyId { get; set; }
        public int GenreId { get; set; }
        public List<SelectListItem>? MovieCaster { get; set; }
        public List<SelectListItem>? MovieGenre { get; set; }
        public List<SelectListItem>? MovieCompany { get; set; }

    }
}
