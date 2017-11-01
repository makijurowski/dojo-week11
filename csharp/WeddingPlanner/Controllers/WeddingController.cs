using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using WeddingPlanner.Models.ManageViewModels;
using WeddingPlanner.Data;
using WeddingPlanner.Services;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Users ActiveUser
        {
            get{ return _context.Users.Where(u => u.UserId.ToString() == HttpContext.Session.GetString("id")).FirstOrDefault(); }
        }
        
        public WeddingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Dashboard dashData = new Dashboard
            {
                Weddings = _context.Weddings.Include(w => w.UserId).ToList(),
                User = ActiveUser
            };
            return View(dashData);
        }

        public IActionResult Create()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create (ViewWedding newWedding)
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if(ModelState.IsValid)
            {
                Weddings wedding = new Weddings
                {
                    BrideName = newWedding.BrideName,
                    GroomName = newWedding.GroomName,
                    Date = newWedding.Date,
                    Address = newWedding.Address,
                    UserId = ActiveUser.UserId
                };
                _context.Weddings.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newWedding);
        }

        public IActionResult Rsvp(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Rsvps rsvp = new Rsvps
            {
                UserId = ActiveUser.UserId,
                WeddingId = id
            };
            _context.Rsvps.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UnRsvp(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Rsvps toDelete = _context.Rsvps.Where(r => r.WeddingId == id)
                                           .Where(r => r.UserId == ActiveUser.UserId)
                                           .SingleOrDefault();
            _context.Rsvps.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Show(int id)
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index");
            }
            // return View(_context.Weddings.Include(w => w.Users).ThenInclude(g => g.UserId).Where(w => w.WeddingId == id).SingleOrDefault());
            return View(_context.Weddings);
        }
    }
}