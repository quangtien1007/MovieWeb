using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Data;
using System.ComponentModel.DataAnnotations.Schema;

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
        public SelectList? Datas { get; set; }
       
    }
}
