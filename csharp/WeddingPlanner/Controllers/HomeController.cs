using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using WeddingPlanner.Services;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private wedding_plannerContext _context;
        private Users ActiveUser
        {
            get{ return _context.Users.Where(u => u.UserId.ToString() == HttpContext.Session.GetString("id")).FirstOrDefault(); }
        }
        private Users ActiveUserDetailed
        {
            get{ return _context.Users.Where(u => u.UserId.ToString() == HttpContext.Session.GetString("id")).FirstOrDefault(); }
        }

        public HomeController(wedding_plannerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Users = _context.Users.ToList();
            return View();
        }

        public IActionResult Show(int id)
        {
            if(HttpContext.Session.GetString("id") == null || HttpContext.Session.GetInt32("id") != id)
            {
                return RedirectToAction("Index");
            }
            return View(this.ActiveUser);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
