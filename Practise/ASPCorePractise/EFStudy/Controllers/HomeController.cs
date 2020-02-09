using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFStudy.Models;
using EFStudy.DataBaseContext;
using EFStudy.Repositories;

namespace EFStudy.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;
        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            var allProducts = repository.GetProductsByPrice(25);

            return View(allProducts);
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
