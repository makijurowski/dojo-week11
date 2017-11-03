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
    [Authorize]
    public class WeddingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public WeddingController(UserManager<ApplicationUser> userManager, 
                                 SignInManager<ApplicationUser> signInManager,
                                 ApplicationDbContext context, 
                                 ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
            // var current_user = _context.ApplicationUsers.SingleOrDefault(user => user.UserName == User.Identity.Name);
            ViewBag.current_user = current_user;
            ViewBag.all_users = _context.ApplicationUsers.ToList();
            ViewBag.all_rsvps = _context.Rsvps.ToList();
            ViewBag.all_weddings = _context.Weddings.ToList();
            if (current_user != null)
            {
                ViewBag.user_rsvps = _context.Rsvps.Where(guest => guest.UserId == current_user.UserId).Select(wedding => wedding.WeddingId).ToList();
            }
            return View("Index");
        }

        [HttpGet]
        [Route("wedding/{WeddingId}")]
        public IActionResult WeddingDetails(int WeddingId)
        {
            var current_wedding = _context.Weddings.Where(wedding => wedding.WeddingId == WeddingId).FirstOrDefault();
            if (current_wedding != null)
            {
                ViewBag.current_wedding = current_wedding;
                ViewBag.current_wedding_rsvps = _context.rsvp_users.ToList();
                ViewBag.all_users = _context.ApplicationUsers.ToList();
                ViewBag.all_weddings = _context.Weddings.ToList();
                return View("Details");
            }
            return View("Index");
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
        [Route("wedding/delete")]
        public IActionResult DeleteWedding(RsvpViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    var current_wedding = _context.Weddings.Where(creator => creator.UserId == current_user.UserId).Where(wedding => wedding.WeddingId == incoming.WeddingId).FirstOrDefault();
                    _context.Weddings.Remove(current_wedding);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                System.Console.WriteLine("This failed.");
                return View("Index", incoming);
            }
            return View("Index");
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
                return View("Index", incoming);
            }
            return View("Index");
        }

        [HttpPost]
        [Route("rsvp/delete")]
        public IActionResult DeleteRsvp(RsvpViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    var current_rsvp = _context.Rsvps.Where(guest => guest.UserId == current_user.UserId).Where(wedding => wedding.WeddingId == incoming.WeddingId).FirstOrDefault();
                    _context.Rsvps.Remove(current_rsvp);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                System.Console.WriteLine("This failed.");
                return View("Index", incoming);
            }
            return View("Index");
        }
    }
}