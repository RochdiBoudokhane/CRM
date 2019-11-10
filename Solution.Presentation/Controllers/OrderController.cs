using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class OrderController : Controller
    {

        IOrderService Service = null;
        public OrderController()
        {
            Service = new OrderService();
        }
        // GET: Order
        public ActionResult Index()
        {
            var orders = new List<OrderVm>();


            foreach (Order odomain in Service.GetMany())
            {
                orders.Add(new OrderVm()
                {
                    Dateres = odomain.Dateres
                });
            }

            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderVm ovm,int id,float prix)
        {
            Order OrderDomain = new Order()
            {
                
                Dateres = ovm.Dateres,
                CustomerId=1,
                ProductId = id,
                Quantity=ovm.Quantity

            };

            Service.Add(OrderDomain);
            Service.Commit();
            //Service.Dispose();

            return View();

        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
