using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using TabApp.Enums;
using Microsoft.EntityFrameworkCore;

namespace TabApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _context;

        public HomeController(ILogger<HomeController> logger, dbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Preview()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var login = _context.LoginCredentials
                .Include(l => l.Person)
                .FirstOrDefaultAsync(l => l.UserName.Equals(username) && l.Password.Equals(password));

            if (login != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, login.Result.Person.Role));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                if (string.IsNullOrEmpty(returnUrl))
                    return Redirect("/");

                return Redirect(returnUrl);
            }

            TempData["Error"] = "Error. Username or Password is invalid";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet("register")]
        public IActionResult Register(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([Bind("ID,UserName,Password,Name,Surname,Address,Email,PhoneNumber")] LoginCredentials loginCredentials, Person person)
        {
            
            if (ModelState.IsValid)
            {
                var email = await _context.Person
                .FirstOrDefaultAsync(l => l.Email.Equals(person.Email));

                var login = await _context.LoginCredentials
                .FirstOrDefaultAsync(l => l.UserName.Equals(loginCredentials.UserName));

                if(login != null)
                {
                    TempData["Error"] = "Login is taken!";
                    return View();
                }

                if (email != null)
                {
                    TempData["Error"] = "Email is taken!";
                    return View();
                }

                _context.Add(person);
                await _context.SaveChangesAsync();
                loginCredentials.ID = person.ID;
                _context.Add(loginCredentials);
                await _context.SaveChangesAsync();

                return View("login");
            }

            TempData["Error"] = "Invalid credentials";
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}