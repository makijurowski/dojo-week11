using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo
{
    public class QuotingDojoController : Controller
    {
        private QuotingDojoContext _context;

        public QuotingDojoController(QuotingDojoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.authors = _context.authors.ToList();
            ViewBag.last_author = _context.authors.LastOrDefault();
            return View();
        }

        [HttpPost]
        [Route("author/create")]
        public IActionResult AddAuthor(AuthorViewModel newAuthor)
        {
            TryValidateModel(newAuthor);
            if (ModelState.IsValid)
            {
                int last_author_id = _context.authors.LastOrDefault().author_id;
                Author author = new Author
                {
                    author_id = last_author_id + 1,
                    name = newAuthor.name
                };
                _context.authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newAuthor);
        }                
    }
}