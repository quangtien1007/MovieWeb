using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movie.Models.Movie;

namespace Movie.Models.Cast
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MovieId")]
        public Movies? Movies { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [StringLength(100)]
        public string? CastName { get; set; }

        [StringLength(255)]
        public string? CastImage { get; set; }
    }
}
