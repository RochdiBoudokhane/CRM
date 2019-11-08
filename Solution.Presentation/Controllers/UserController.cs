using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IUserService Service = null;


        public UserController()
        {
            Service = new UserService();

        }
        // GET: User
        public ActionResult Index(String searchString)
        {
            // return View(Service.GetMany());
            var Users = new List<UserVm>();
            IEnumerable<User> userDomain = Service.GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                //sans service
                //filmDomain = filmDomain.Where(m => m.Gender.Contains(searchString)).ToList();
                //avec service 
                // filmDomain = Service.GetMany(m => m.Gender.Contains(searchString));
                //avec service specifique
                //userDomain = Service.GetFilmByTitle(searchString);
            }

            foreach (User fdomain in userDomain)
            {
                Users.Add(new UserVm()
                {
                    FirstName = fdomain.FirstName,
                    LastName = fdomain.LastName,
                    Email = fdomain.Email,
                    ImageUrl = fdomain.ImageUrl,
                    UserId = fdomain.UserId
                });
            }
            return View(Users);

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            User p = Service.GetById(id);
            UserVm p1 = new UserVm()
            {

                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserVm userVm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            User UserAdd = new User()
            {
                ImageUrl = file.FileName,
                // ImageUrl = userVm.ImageUrl,
                FirstName = userVm.FirstName,
                LastName = userVm.LastName,
                Email = userVm.Email,
                Password = userVm.Password,
                ConfirmPassword = userVm.ConfirmPassword
            };
            Service.Add(UserAdd);
            Service.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Upload/"),
                    fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            User p = Service.GetById(id);
            UserVm p1 = new UserVm()
            {

                ImageUrl = p.ImageUrl,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Password = p.Password


            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserVm userVm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Edit");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    User p = Service.GetById(id);

                    p.ImageUrl = file.FileName;
                    // ImageUrl = userVm.ImageUrl,
                    p.FirstName = userVm.FirstName;
                    p.LastName = userVm.LastName;
                    p.Email = userVm.Email;
                    p.Password = userVm.Password;
                    p.ConfirmPassword = userVm.ConfirmPassword;





                    var fileName = "";
                    if (file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var path = Path.
                            Combine(Server.MapPath("~/Content/Upload/"),
                            fileName);
                        file.SaveAs(path);
                    }

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    Service.Update(p);
                    Service.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(userVm);

            }
            catch
            {
                return View();
            }
        }




        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User p = Service.GetById(id);
            UserVm pvm = new UserVm()
            {

                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email

            };
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(pvm);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User prod = Service.GetById(id);
            Service.Delete(prod);
            Service.Commit();
            return RedirectToAction("Index");
        }
    }
}
