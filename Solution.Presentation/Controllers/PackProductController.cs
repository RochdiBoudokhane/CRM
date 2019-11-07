using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class PackProductController : Controller
    {
        PackProductService service = null;
        // GET: PackProduct

        public PackProductController()
        {
            service = new PackProductService();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: PackProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PackProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackProduct/Create
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

        // GET: PackProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PackProduct/Edit/5
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

        // GET: PackProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PackProduct/Delete/5
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
    }
}
