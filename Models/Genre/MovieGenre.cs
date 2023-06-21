using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movie.Models.Movie;

namespace Movie.Models.Genre
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movies? Movies { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
