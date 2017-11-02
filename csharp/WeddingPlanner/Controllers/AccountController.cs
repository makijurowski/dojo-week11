using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using WeddingPlanner.Data;
using WeddingPlanner.Models.ViewModels;

namespace WeddingPlanner.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                 ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("account")]
        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("account/register")]
        public IActionResult Register()
        {
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Fname = incoming.Fname,
                    Lname = incoming.Lname,
                    Email = incoming.REmail,
                    UserName = incoming.REmail,
                    Birthdate = incoming.Birthdate,
                };
                var result = await _userManager.CreateAsync(user, incoming.RPassword);
                if (result.Succeeded)
                {
                    // // Put new user to Customer Table.
                    // Customer new_customer = new Customer
                    // {
                    //     ApplicationUserEmail = incoming.Email,
                    //     Created = DateTime.Now,
                    // };
                    // _context.Customers.Add(new_customer);
                    // _context.SaveChanges();
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
        [Route("account/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("account/Login")]
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
                    ModelState.AddModelError("", "This email and password combination does not match an account.");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}