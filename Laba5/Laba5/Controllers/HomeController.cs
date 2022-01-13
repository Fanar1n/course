using Laba5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Controllers
{
    public class HomeController : Controller
    {
        RestaurantContext db;
        public HomeController(RestaurantContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Employees.ToList());
        }
    }
}
