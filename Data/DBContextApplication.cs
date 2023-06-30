using Microsoft.EntityFrameworkCore;
using Movie.Models.Cast;
using Movie.Models.Company;
using Movie.Models.Country;
using Movie.Models.Genre;
using Movie.Models.Keyword;
using Movie.Models.Movie;
using Movie.Models.Post;
using Movie.Models.User;
using Movie.Models;

namespace Movie.Data
{
    public class DBContextApplication : DbContext
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> options) : base(options) { }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCompany> MovieCompanys { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieKeyword> MovieKeywords { get; set; }
        public DbSet<PostCast> PostCasts { get; set; }
        public DbSet<PostGenre> PostGenres { get; set; }
        public DbSet<ProductionCountry> ProductionCountrys { get; set; }
        public DbSet<Movie.Models.MovieDBViewModel>? MovieDBViewModel { get; set; }

        #endregion
    }
}