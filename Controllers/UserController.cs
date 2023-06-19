using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models.User;
using System.Security.Cryptography;

namespace Movie.Controllers
{
    public class UserController : Controller
    {
        private readonly DBContextApplication _db;

        public UserController(DBContextApplication db) 
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if(_db.Users.Any(u => u.Email == request.Email)) 
            {
                return BadRequest("User already exists");
            }
            else
            {
                CreatePasswordHash(request.Password, out Byte[] passwordHash, out Byte[] passwordSalt);

                var User = new User
                {
                    Email = request.Email,
                    Role = 1,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerifyAt = DateTime.Now,
                    VerificationToken = CreateRandomToken(),
                    ResetTokenExpires = DateTime.Now.AddDays(1),
                };

                _db.Users.Add(User);

                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if(user == null)
            {
                return NotFound();
            }
            if (user.VerifyAt == null)
            {
                return NotFound();
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return NotFound();
            }
            TempData["success"] = "login successfully";
;            return View();
        }

        private void CreatePasswordHash(string password, out Byte[] passwordHash, out Byte[] passwordSalt) 
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {   
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
