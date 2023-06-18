using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MovieId")]
        public Movies? Movies { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
