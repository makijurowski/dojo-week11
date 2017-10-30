using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DojoLeague.Factories;
using DojoLeague.Models;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;

        public DojoController()
        {
            dojoFactory = new DojoFactory();
        }

        [HttpGet]
        [Route("dojo")]
        public IActionResult Index()
        {
            ViewBag.AllDojos = dojoFactory.FindAll();
            ViewBag.Dojo1 = dojoFactory.FindById(1);
            ViewBag.Maki = dojoFactory.FindNinjasByLocation("Seattle");
            return View("dojo");
        }

        [HttpPost]
        [Route("AddDojo")]
        public IActionResult AddDojo(Dojo dojo)
        {
            ViewBag.NewDojo = dojo;
            dojoFactory.AddDojo(dojo);
            return RedirectToAction("Index", "Home");
        }
    }
}