using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
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
