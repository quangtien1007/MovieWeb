namespace Movie.Models.Post
{
    public class PostViewModel
    {
        public string Title { get; set; } = string.Empty;
        public IFormFile? Thumbnail { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Viewed { get; set; } = 0;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
