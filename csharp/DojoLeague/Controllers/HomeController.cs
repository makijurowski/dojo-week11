using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoLeague.Factories;
using DojoLeague.Models;

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            userFactory = new UserFactory();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Users = userFactory.FindAll();
            return View();
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
