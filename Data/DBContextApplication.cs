using Microsoft.EntityFrameworkCore;
using Movie.Models.Cast;
using Movie.Models.Company;
using Movie.Models.Country;
using Movie.Models.Genre;
using Movie.Models.Keyword;
using Movie.Models.Movie;
using Movie.Models.User;

namespace Movie.Data
{
    public class DBContextApplication : DbContext
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> options) : base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCompany> MovieCompanys { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieKeyword> MovieKeywords { get; set; }
        public DbSet<ProductionCountry> ProductionCountrys { get; set; }

        #endregion
    }
}
