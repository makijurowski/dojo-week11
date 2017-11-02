using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Data;
using WeddingPlanner.Models;
using WeddingPlanner.Models.ViewModels;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public WeddingController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.current_user = current_user;
            ViewBag.users = _context.ApplicationUsers.ToList();
            ViewBag.rsvps = _context.Rsvps.ToList();
            ViewBag.weddings = _context.Weddings.ToList();
            ViewBag.user_rsvps = _context.Rsvps.Where(guest => guest.UserId == current_user.UserId).Select(wedding => wedding.WeddingId).ToList();
            return View();
        }

        [HttpGet]
        [Route("wedding/add")]
        public IActionResult WeddingForm()
        {
            return View();
        }

        [HttpPost]
        [Route("wedding/add")]
        public async Task<IActionResult> AddWedding(WeddingViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    Weddings NewWedding = new Weddings
                    {
                        UserId = current_user.UserId,
                        GroomName = incoming.GroomName,
                        BrideName = incoming.BrideName,
                        Address = incoming.Address,
                        Date = incoming.Date
                    };
                    await _context.Weddings.AddAsync(NewWedding);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                System.Console.WriteLine("This failed.");
            }
            return View("WeddingForm", incoming);
        }

        [HttpPost]
        [Route("rsvp/add")]
        public async Task<IActionResult> AddRsvp(RsvpViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    Rsvps NewRsvp = new Rsvps
                    {
                        UserId = current_user.UserId,
                        WeddingId = incoming.WeddingId
                    };
                    await _context.Rsvps.AddAsync(NewRsvp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                System.Console.WriteLine("This failed.");
            }
            return View("Index");
        }
    }
}