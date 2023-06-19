using System.ComponentModel.DataAnnotations;

namespace Movie.Models.User
{
    public class UserLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        public bool RememberLogin { get; set; }
    }
}
