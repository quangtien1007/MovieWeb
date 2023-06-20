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
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Viewed { get; set; } = 0;
        public string? Movie_Status { get; set; } = "New";
    }
}
