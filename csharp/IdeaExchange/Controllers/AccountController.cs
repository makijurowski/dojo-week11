using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaExchange.Data;
using IdeaExchange.Models;
using IdeaExchange.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdeaExchange.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("main")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("main/register")]
        public IActionResult Register()
        {
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("main/register")]
        public async Task<IActionResult> Register(RegisterViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Fname = incoming.Fname,
                    Alias = incoming.Alias,
                    UserName = incoming.REmail,
                    Email = incoming.REmail
                };
                var result = await _userManager.CreateAsync(user, incoming.RPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Index");
        }

        [HttpGet]
        [Route("main/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("main/Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(incoming.LEmail, incoming.LPassword, incoming.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The email and password combination you entered is not correct.");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("main/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}