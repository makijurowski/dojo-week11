using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter
{
    public class RestaurantController : Controller
    {
        // private readonly DbConnector _dbConnector;
        private aspnetContext _context;

        public RestaurantController(aspnetContext context)
        {
            // _dbConnector = connect;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> AllUsers = (dynamic)_context.Users.ToList();
            return View();
        }
    }
}