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

        public int MovieId { get; set; }
        public Movies? Movies { get; set; }

        public int CastId { get; set; }
        public Cast? Cast { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [StringLength(100)]
        public string? CharacterName { get; set; }
    }
}
