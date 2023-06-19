using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movie.Models.Movie;

namespace Movie.Models.Company
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
