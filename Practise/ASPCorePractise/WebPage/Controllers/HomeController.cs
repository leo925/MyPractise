using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebPage.Models;

namespace WebPage.Controllers
{
    [NonController]
    public class OtherClass
    {

        public IMyService Service { get; set; }
        public OtherClass(IMyService serv)
        {
            Service = serv;

        }
        public void Show()
        {
            var testR = Service.Show();

        }
    }

    public class HomeController : Controller
    {
        IMyService Serv;
        public IServiceProvider SP { get; set; }             
        public HomeController(IMyService serv, IServiceProvider sp)
        { Serv = serv;
SP= sp; 
}
        public IActionResult Index()
        {
            
            var testR = Serv.Show();
            var serv2 = this.SP.GetService(typeof(IMyService)) as IMyService;
            var other = new OtherClass(serv2);
            other.Show();
            throw new Exception("test !");

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

    public class CustomResult : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
