using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models.Post
{
    [Table("Post")]
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Viewed { get; set; } = 0;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string? Status { get; set; }
    }
}
