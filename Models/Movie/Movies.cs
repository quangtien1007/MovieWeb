using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models.Movie
{
    [Table("Movie")]
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(255)]
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Viewed { get; set; }
        public string? Movie_Status { get; set; }
    }
}
