using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practise.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        //[OutputCache(Duration =20,CacheProfile ="myCatch",VaryByParam ="name")]
        public ActionResult Search(string name)
        {
             
            var c = RouteData.Values["controller"];
            var p = RouteData.Values["name"];
            if (name == "file")
            {
                var path = Server.MapPath("~/Assets/Files/readme.txt");
                return File(new FileStream(path, FileMode.Open), "application/octet-stream", "downloaded");
            }
            else if (name == "getdata")
            {
                return Json(new
                {
                    Name = "leo",
                    age = 19
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.Private);
                return View();
            }
            
        }


        public ActionResult GetData()
        {
            return Json(new
            {
                Name="leo",
                age=19
            }, JsonRequestBehavior.AllowGet);
        }
    }
}