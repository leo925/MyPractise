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
    public class ReaderController : Controller
    {
        private MyPractiseDb db = new MyPractiseDb();

        // GET: Reader
        public ActionResult Index()
        {
            return View(db.Readers.ToList());
        }

        // GET: Reader/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReaderModel readerModel = db.Readers.Find(id);
            if (readerModel == null)
            {
                return HttpNotFound();
            }
            return View(readerModel);
        }

        // GET: Reader/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reader/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IP,Port,ConnectionStatus,ReaderType")] ReaderModel readerModel)
        {
            if (ModelState.IsValid)
            {
                db.Readers.Add(readerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(readerModel);
        }

        // GET: Reader/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReaderModel readerModel = db.Readers.Find(id);
            if (readerModel == null)
            {
                return HttpNotFound();
            }
            return View(readerModel);
        }

        // POST: Reader/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IP,Port,ConnectionStatus,ReaderType")] ReaderModel readerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(readerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(readerModel);
        }

        // GET: Reader/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReaderModel readerModel = db.Readers.Find(id);
            if (readerModel == null)
            {
                return HttpNotFound();
            }
            return View(readerModel);
        }

        // POST: Reader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReaderModel readerModel = db.Readers.Find(id);
            db.Readers.Remove(readerModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
