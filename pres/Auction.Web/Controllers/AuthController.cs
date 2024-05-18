using Microsoft.AspNetCore.Mvc;
using Auction.Web.Models;
namespace Auction.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServise _authServise;
        private readonly IAkkRepos _akkRepos;
        public AuthController(IAuthServise authServise,IAkkRepos akkRepos)
        {
            _authServise = authServise;
            _akkRepos = akkRepos;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid login or password");
            }
            var user = _authServise.GetUserByLogin(model.Login);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (_authServise.Login(model.Login, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            return BadRequest("Invalid login or password");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid registration data");
            }
            var user = _akkRepos.GetUserByLogin(model.Login);
            if (user != null)
            {
                return BadRequest("Login already exists");
            }
            _akkRepos.RegisterUser(model.Name, model.Login, model.Password);
            if (_authServise.Register(model.Name, model.Login, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            return BadRequest("Invalid registration data");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
