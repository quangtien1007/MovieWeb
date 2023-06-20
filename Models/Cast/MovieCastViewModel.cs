using Movie.Models.Movie;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models.Cast
{
    public class MovieCastViewModel
    {
        public string MovieId { get; set; }    
        public string CastId { get; set; }
        public string? Gender { get; set; }
        public string? CharacterName { get; set; }
    }
}
