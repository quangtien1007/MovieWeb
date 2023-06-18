using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MovieId")]
        public Movies? Movies { get; set; }

        [ForeignKey("GenderId")]
        public Gender? Gender { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }

        public string? CastName { get; set; }  
    }
}
