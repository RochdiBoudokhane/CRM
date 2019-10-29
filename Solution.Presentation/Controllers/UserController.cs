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
    public class UserController : Controller
    {
        IUserService Service = null;

        public UserController()
        {
            Service = new UserService();
        }
        // GET: User
        public ActionResult Index()
        {
            //return View(Service.GetMany());

            var users = new List<SimpleUserCRM>();
            foreach (User SUser in Service.GetMany())
            {
               users.Add(new SimpleUserCRM()
                {
                   FirstName = SUser.FirstName,
                   LastName = SUser.LastName,
                   Email = SUser.Email,
                   Password = SUser.Password,
                   ConfirmPassword = SUser.ConfirmPassword,
                   ImageUrl = SUser.ImageUrl
               });

            }
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {            
         return View();                        
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(SimpleUserCRM SUser)
        {
            
            User UserAdd = new User()
            {
                FirstName = SUser.FirstName,
                LastName = SUser.LastName,
                Email = SUser.Email,
                Password = SUser.Password,
                ConfirmPassword = SUser.ConfirmPassword,
                ImageUrl=SUser.ImageUrl
            };
            Service.Add(UserAdd);
            Service.Commit();
            //Service.Dispose();
              return RedirectToAction("Index");
            //return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
