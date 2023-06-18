using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    [Table("MovieCompany")]
    public class MovieCompany
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MovieId")]
        public Movies? Movies { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }
    }
}
