using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFStudy.Models;
using EFStudy.DataBaseContext;

namespace EFStudy.Controllers
{
    public class HomeController : Controller
    {
        private EFDatabaseContext context;
        public HomeController(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var allProducts = context.Producs;

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
