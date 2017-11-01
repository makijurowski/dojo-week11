using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.notes = _context.notes.ToList();
            ViewBag.last_author = _context.authors.LastOrDefault();
            ViewBag.last_quote = _context.quotes.LastOrDefault();
            ViewBag.last_category = _context.categories.LastOrDefault();
            ViewBag.last_note = _context.notes.LastOrDefault();
            return View();
        }

        [HttpPost]
        [Route("/author/create")]
        public IActionResult AddAuthor(AuthorViewModel incoming)
        {
            TryValidateModel(incoming);
            if (ModelState.IsValid)
            {
                int last_author_id = _context.authors.LastOrDefault().author_id;
                Author newAuthor = new Author
                {
                    author_id = last_author_id + 1,
                    author_name = incoming.author_name
                };
                _context.authors.Add(newAuthor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.ToList();
            ViewBag.authors = _context.authors.ToList();
            ViewBag.notes = _context.notes.ToList();
            return View("Index", incoming);
        }

        [HttpPost]
        [Route("/quote/create")]
        public IActionResult AddQuote(QuoteViewModel incoming)
        {
            TryValidateModel(incoming);
            if (ModelState.IsValid)
            {
                // Note AKA Meta
                int last_note = _context.notes.LastOrDefault().note_id;
                Note newNote = new Note
                {
                    note_id = last_note + 1,
                    note_text = incoming.note_text
                };
                _context.notes.Add(newNote);
                _context.SaveChanges();

                // Add to instance db
                newNote = _context.notes.Last();

                // Quote
                int last_quote_id = _context.quotes.LastOrDefault().quote_id;
                Author quote_author = _context.authors.SingleOrDefault(author => author.author_id == incoming.author_id);
                Category category = _context.categories.SingleOrDefault(cat => cat.category_id == incoming.category_id);
                Quote newQuote = new Quote
                {
                    quote_id = last_quote_id + 1,
                    quote_text = incoming.quote_text,
                    author_id = incoming.author_id,
                    author = quote_author,
                    note_id = newNote.note_id,
                    note = newNote,
                    category_id = incoming.category_id,
                    category = category
                };
                _context.quotes.Add(newQuote);
                _context.SaveChanges();
                
                // Add to instance db
                newQuote = _context.quotes.Last();

                // Quote category
                // QuoteCategory quote_category = new QuoteCategory();
                // quote_category.category = category;
                // quote_category.quote = newQuote;
                // _context.quote_categories.Add(quote_category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.ToList();
            ViewBag.authors = _context.authors.ToList();
            ViewBag.notes = _context.notes.ToList();
            return View("Index", incoming);
        }               

        [HttpPost]
        [Route("/category/create")]
        public IActionResult AddCategory(CategoryViewModel incoming)
        {
            TryValidateModel(incoming);
            if (ModelState.IsValid)
            {
                int last_category_id = _context.categories.LastOrDefault().category_id;
                Category newCategory = new Category
                {
                    category_id = last_category_id + 1,
                    category_name = incoming.category_name
                };
                _context.categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.ToList();
            ViewBag.authors = _context.authors.ToList();
            ViewBag.notes = _context.notes.ToList();
            return View("Index", incoming);
        }                
    }
}