using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise.Controllers
{
    public class ReadersController : Controller
    {
        // GET: Readers
         [OutputCache(Duration =20)]
        public ActionResult Index()
        {
            List<ReaderModel> readers = GenerateReaders();

            return View(readers);
        }

       

        // GET: Readers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Readers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Readers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Readers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Readers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private static List<ReaderModel> GenerateReaders()
        {
            List<ReaderModel> readers = new List<ReaderModel>();
            for (int i = 0; i < 15; i++)
            {
                ReaderModel reader = new ReaderModel()
                {
                    Name = "reader" + i.ToString(),
                    IP = "10,1,10," + i.ToString(),
                    Port = i,
                    Id = i
                };
                readers.Add(reader);
            }
            return readers;
        }
    }
}
