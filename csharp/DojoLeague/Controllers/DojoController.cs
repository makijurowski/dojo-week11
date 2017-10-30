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
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;

        public DojoController()
        {
            dojoFactory = new DojoFactory();
            ninjaFactory = new NinjaFactory();
        }

        [HttpGet]
        [Route("Dojo")]
        public IActionResult DojoIndex()
        {
            ViewBag.Dojo = null;
            ViewBag.AllDojos = dojoFactory.FindAll();
            ViewBag.AllNinjas = ninjaFactory.FindAll();
            return View("Dojo");
        }

        [HttpPost]
        [Route("AddDojo")]
        public IActionResult AddDojo(Dojo dojo)
        {
            ViewBag.NewDojo = dojo;
            dojoFactory.AddDojo(dojo);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Dojo/{id}")]
        public IActionResult DojoDetails(int id)
        {
            ViewBag.dojo_id = id;
            ViewBag.Dojo = dojoFactory.FindById(id);
            ViewBag.AllDojos = dojoFactory.FindAll();
            ViewBag.AllNinjas = ninjaFactory.FindAll();
            return View("Dojo");
        }
    }
}