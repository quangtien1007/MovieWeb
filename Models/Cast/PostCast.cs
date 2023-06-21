using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movie.Models.Post;

namespace Movie.Models.Cast
{
    [Table("PostCast")]
    public class PostCast
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public Posts? Post { get; set; }
        public int CastId { get; set; }
        public Cast? Cast { get; set; }
    }
}
