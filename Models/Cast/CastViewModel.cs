using System.ComponentModel.DataAnnotations;

namespace Movie.Models.Cast
{
    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
