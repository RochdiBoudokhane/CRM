using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class PackController : Controller
    {
        IPackService service = null;

        public PackController()
        {
            service = new PackService();
        }

        // GET: Pack
        public ActionResult Index(string SearchString, string date, int? i)
        {
            var Packs = new List<PackVM>();


            foreach (Pack item in service.GetPacksearch(SearchString, date))
            {
                Packs.Add(new PackVM()
                {
                    Description = item.Description,
                 
                    PackName = item.PackName,
                    StartDate=item.StartDate,
                    EndDate=item.EndDate,
                    Quantity=item.Quantity,
                    TypePack=item.TypePack
                });
             
            }


            return View(Packs);


        }

        // GET: Pack/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pack p = service.GetById(id);
            PackVM p1 = new PackVM()
            {
                TypePack = p.TypePack,
                PackName = p.PackName,
                Description = p.Description,
                Quantity = p.Quantity,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                PackId = p.PackId,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // GET: Pack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pack/Create
        [HttpPost]
        public ActionResult Create(PackVM ovm)
        {
            Pack p = new Pack()
            {
                TypePack = ovm.TypePack,
                PackName = ovm.PackName,
                Description = ovm.Description,
                Quantity = ovm.Quantity,
                StartDate = ovm.StartDate,
                EndDate = ovm.EndDate,
            };
            service.Add(p);
            service.Commit();
            //service.Dispose();
            return RedirectToAction("Index");
        }

        // GET: Pack/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pack p = service.GetById(id);
            PackVM p1 = new PackVM()
            {
                Description = p.Description,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                PackName = p.PackName,
                TypePack = p.TypePack,
                Quantity = p.Quantity

            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }

        // POST: Pack/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PackVM ovm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Pack p = service.GetById(id);

                    p.Description = ovm.Description;
                    p.EndDate = ovm.EndDate;
                    p.StartDate = ovm.StartDate;
                    p.PackName = ovm.PackName;
                    p.TypePack = ovm.TypePack;
                    p.Quantity = ovm.Quantity;


                    if (p == null)
                        return HttpNotFound();

                    service.Update(p);
                    service.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(ovm);

            }
            catch
            {
                return View();
            }
        }


        // GET: Pack/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pack p = service.GetById(id);
            PackVM p1 = new PackVM()
            {
                Description = p.Description,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                PackName = p.PackName,
                TypePack = p.TypePack,
                Quantity = p.Quantity

            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }

        // POST: Pack/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PackVM aftervm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)

                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Pack p = service.GetById(id);
                    PackVM p1 = new PackVM()
                    {
                        Description = p.Description,
                        EndDate = p.EndDate,
                        StartDate = p.StartDate,
                        PackName = p.PackName,
                        TypePack = p.TypePack,
                        Quantity = p.Quantity

                    };
                    if (p == null)
                        return HttpNotFound();
                    service.Delete(p);
                    service.Commit();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(aftervm);

            }
            catch
            {
                return View();
            }
        }
    }
}
