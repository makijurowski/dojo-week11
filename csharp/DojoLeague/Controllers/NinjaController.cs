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
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
        }

        [HttpGet]
        [Route("ninja")]
        public IActionResult Index()
        {
            ViewBag.AllNinjas = ninjaFactory.FindAll();
            ViewBag.Ninja1 = ninjaFactory.FindById(1);
            ViewBag.Seattle = ninjaFactory.FindByLocation("Seattle");
            ViewBag.Maki = ninjaFactory.FindByName("Maki");
            return View("ninja");
        }

        [HttpPost]
        [Route("AddNinja")]
        public IActionResult AddNinja(Ninja ninja)
        {
            ViewBag.NewNinja = ninja;
            ninjaFactory.AddNinja(ninja);
            return RedirectToAction("Index", "Ninja");
        }
    }
}