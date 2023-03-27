using TestTaskSupportDashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestTaskSupportDashboard.Controllers
{
    public class LoginController : Controller
    {
        private LoginContext logins;

        public LoginController(LoginContext context)
        {
            logins = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SupportOperator supportOperator)
        {
            if (ModelState.IsValid)
            {
                SupportOperator user = await logins.SupportOperators
                    .Include(op => op.Role)
                    .FirstOrDefaultAsync(op => op.Email == supportOperator.Email && op.Password == supportOperator.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("TicketsList", "Ticket");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(supportOperator);
        }

        private async Task Authenticate(SupportOperator op)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, op.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, op.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
