using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models.Cast
{
    [Table("Cast")]
    public class Cast
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(10)]
        public string? Gender { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime Birth { get; set; }
    }
}
