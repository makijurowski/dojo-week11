using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly DbConnector _dbConnector;
        private RestaurantContext _context;

        public RestaurantController(DbConnector connect, RestaurantContext context)
        {
            _dbConnector = connect;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> AllUsers = _context.Users.ToList();
            return View();
        }
    }
}