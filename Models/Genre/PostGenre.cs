using Movie.Models.Post;
namespace Movie.Models.Genre
{
    public class PostGenre
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Posts? Post { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
