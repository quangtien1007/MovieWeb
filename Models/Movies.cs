using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    [Table("Movie")]
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Viewed { get; set; }
        public int Movie_Status { get; set; }
    }
}
