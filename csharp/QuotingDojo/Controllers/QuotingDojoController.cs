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
            ViewBag.categories = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.ToList();
            ViewBag.authors = _context.authors.ToList();
            ViewBag.last_author = _context.authors.LastOrDefault();
            ViewBag.last_quote = _context.quotes.LastOrDefault();
            ViewBag.last_category = _context.categories.LastOrDefault();
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

        [HttpPost]
        [Route("quote/create")]
        public IActionResult AddQuote(QuoteViewModel newQuote)
        {
            TryValidateModel(newQuote);
            if (ModelState.IsValid)
            {
                int last_quote_id = _context.quotes.LastOrDefault().quote_id;
                Quote quote = new Quote
                {
                    quote_id = last_quote_id + 1,
                    quote = newQuote.quote,
                    author_id = newQuote.author_id
                };
                _context.quotes.Add(quote);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newQuote);
        }               

        [HttpPost]
        [Route("category/create")]
        public IActionResult AddCategory(CategoryViewModel newCategory)
        {
            TryValidateModel(newCategory);
            if (ModelState.IsValid)
            {
                int last_category_id = _context.categories.LastOrDefault().category_id;
                Category category = new Category
                {
                    category_id = last_category_id + 1,
                    name = newCategory.name
                };
                _context.categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }                
    }
}