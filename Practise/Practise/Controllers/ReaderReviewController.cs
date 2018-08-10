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

       [HttpGet]
        public ActionResult Index([Bind(Prefix ="id")]int ReaderId)
        {
            var reader = db.Readers.Find(ReaderId);
            if (reader != null)
            {
                return View(reader);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int ReaderId)
        {
            return View(new ReaderReviewModel() {
                 ReaderId= ReaderId
            });
        }

        [HttpPost]
        public ActionResult Create(ReaderReviewModel review)
        {
            if(this.ModelState.IsValid)
            {
                db.ReaderReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index",new
                {
                    id=review.ReaderId
                });
            }
            return View(review);
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
