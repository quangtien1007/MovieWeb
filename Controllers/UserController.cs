using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models.User;
using System.Security.Claims;
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
                    Role = "Admin",
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
        public IActionResult Login(string returnUrl = "/Login")
        {
            UserLoginRequest objLoginModel = new UserLoginRequest();
            objLoginModel.ReturnUrl = returnUrl;
            return View(objLoginModel);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
                bool pass = VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
                if (user != null && pass)
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = request.RememberLogin
                    });
                    TempData["success"] = "Login successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Email or Password is invalid";
                    ViewBag.Message = "Invalid Credential";
                    return View(user);
                }
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return RedirectToAction("Index","Home");
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
