using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movie.Models.Movie;

namespace Movie.Models.Country
{
    [Table("ProductionCountry")]
    public class ProductionCountry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MovieID")]
        public Movies? Movies { get; set; }

        [ForeignKey("CountryID")]
        public Country? Country { get; set; }
    }
}
