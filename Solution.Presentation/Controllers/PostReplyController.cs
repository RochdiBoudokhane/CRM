using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class PostReplyController : Controller
    {
        // GET: PostReply
        public ActionResult Index()
        {
            return View();
        }

        // GET: PostReply/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostReply/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostReply/Create
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

        // GET: PostReply/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostReply/Edit/5
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

        // GET: PostReply/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostReply/Delete/5
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
