using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Data;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private ApplicationDbContext _context;

        public WeddingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.users = _context.ApplicationUsers.ToList();
            ViewBag.rsvps = _context.Rsvps.ToList();
            ViewBag.weddings = _context.Weddings.ToList();
            return View();

        }

        // [HttpPost]
        // [Route("user/create")]
        // public IActionResult AddUser(UserViewModel incoming)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         System.Console.WriteLine("All good in da hood!");
        //         ApplicationUser NewUser = new ApplicationUser{
        //             name = incoming.name,
        //         };
        //         _context.users.Add(NewUser);
        //         _context.SaveChanges();
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("All is not good in da hood. :(");
        //     }
        //     return RedirectToAction("Index");
        // }
        // [HttpPost]
        // [Route("wedding/create")]
        // public IActionResult AddQuote(QuoteViewModel incoming)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         //meta
        //         Meta newMeta = new Meta();
        //         newMeta.notes = incoming.meta;
        //         _context.metas.Add(newMeta);
        //         _context.SaveChanges();
        //         //reassign to db instance of meta
        //         newMeta = _context.metas.Last();
        //         //quote
        //         Quote newQuote = new Quote();
        //         ApplicationUser auth = _context.users.SingleOrDefault(ApplicationUser=>ApplicationUser.userid == incoming.userid);
        //         newQuote.user = auth;
        //         newQuote.quote = incoming.quote;
        //         newQuote.meta = newMeta;
        //         _context.weddings.Add(newQuote);
        //         _context.SaveChanges();
        //         // reassign newQuote to db instance
        //         newQuote = _context.weddings.Last();
        //         //quotersvps
        //         QuoteCategory newQcat = new QuoteCategory();
        //         Category cat = _context.rsvps.SingleOrDefault(Category=>Category.categoryid == incoming.categoryid);
        //         newQcat.category = cat;
        //         newQcat.quote = newQuote;
        //         _context.quotersvps.Add(newQcat);
        //         _context.SaveChanges();                
        //         System.Console.WriteLine("Goodness!");
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("Badness. :(");
        //     }
        //     return RedirectToAction("Index");
        // }
    }
}
