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
        public IActionResult Index()
        {
            return View();
        }                
    }
}