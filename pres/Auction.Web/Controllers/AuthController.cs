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
        public IActionResult Login(LoginModel model)
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
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
