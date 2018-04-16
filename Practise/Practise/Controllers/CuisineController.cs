using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        [OutputCache(Duration =20,CacheProfile ="myCatch",VaryByParam ="name")]
        public ActionResult Search(string name)
        {
            if (name == "file")
            {
                var path = Server.MapPath("~/Assets/Files/readme.txt");
                return File(new FileStream(path, FileMode.Open),"text/plain","down name");
            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.Private);
                return View();
            }
            
        }
    }
}