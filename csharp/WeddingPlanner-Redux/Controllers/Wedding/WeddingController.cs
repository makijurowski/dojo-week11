using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingPlannerContext _context;
        public WeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.authors = _context.authors.ToList();
            ViewBag.cats = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.ToList();
            return View();

        }
        [HttpPost]
        [Route("author/create")]
        public IActionResult AddAuthor(AuthorViewModel incoming)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("All good in da hood!");
                Author NewAuthor = new Author{
                    name = incoming.name,
                };
                _context.authors.Add(NewAuthor);
                _context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("All is not good in da hood. :(");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("quote/create")]
        public IActionResult AddQuote(QuoteViewModel incoming)
        {
            if(ModelState.IsValid)
            {
                //meta
                Meta newMeta = new Meta();
                newMeta.notes = incoming.meta;
                _context.metas.Add(newMeta);
                _context.SaveChanges();
                //reassign to db instance of meta
                newMeta = _context.metas.Last();
                //quote
                Quote newQuote = new Quote();
                Author auth = _context.authors.SingleOrDefault(Author=>Author.authorid == incoming.authorid);
                newQuote.author = auth;
                newQuote.quote = incoming.quote;
                newQuote.meta = newMeta;
                _context.quotes.Add(newQuote);
                _context.SaveChanges();
                // reassign newQuote to db instance
                newQuote = _context.quotes.Last();
                //quotecats
                QuoteCategory newQcat = new QuoteCategory();
                Category cat = _context.categories.SingleOrDefault(Category=>Category.categoryid == incoming.categoryid);
                newQcat.category = cat;
                newQcat.quote = newQuote;
                _context.quotecategories.Add(newQcat);
                _context.SaveChanges();                
                System.Console.WriteLine("Goodness!");
            }
            else
            {
                System.Console.WriteLine("Badness. :(");
            }
            return RedirectToAction("Index");
        }
    }
}
