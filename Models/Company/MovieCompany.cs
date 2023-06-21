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
        public int MovieId { get; set; }
        public Movies? Movies { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
