using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Practise.Db;

namespace Practise.Controllers
{
    public class ReaderReviewController : Controller
    {
        private MyPractiseDb db = new MyPractiseDb();

        // GET: ReaderReviewModels
        public ActionResult Index([Bind(Prefix ="id")]int readerId)
        {
            var reader = db.Readers.Find(readerId);
            if (reader != null)
            {
                return View(reader);
            }
            return HttpNotFound();
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
