using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DojoLeague.Factories;
using DojoLeague.Models;
using DojoLeague.Controllers;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }

        [HttpGet]
        [Route("Ninja")]
        public IActionResult NinjaIndex()
        {
            ViewBag.Ninja = null;
            ViewBag.AllNinjas = ninjaFactory.FindAll();
            ViewBag.AllDojos = dojoFactory.FindAll();
            return View("Ninja");
        }

        [HttpPost]
        [Route("AddNinja")]
        public IActionResult AddNinja(Ninja ninja)
        {
            ViewBag.NewNinja = ninja;
            ninjaFactory.AddNinja(ninja);
            return RedirectToAction("NinjaIndex", "Ninja");
        }

        [HttpGet]
        [Route("Ninja/{id}")]
        public IActionResult NinjaDetails(int id)
        {
            ViewBag.ninja_id = id;
            ViewBag.AllNinjas = ninjaFactory.FindAll();
            ViewBag.AllDojos = dojoFactory.FindAll();
            ViewBag.Ninja = ninjaFactory.FindById(id);
            return View("Ninja");
        }
    }
}